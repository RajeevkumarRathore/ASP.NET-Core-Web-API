using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Dtos;
using Application.Common.Helpers;
using Application.Common.Response;
using Domain.Entities;
using Domain.Entities.LocalCheck;
using DTO.Request.DispatchLocation;
using DTO.Response;
using DTO.Response.DispatchLocation;
using Helper;
using Infrastructure.Implementation.Common;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Infrastructure.Implementation.Services
{
    public class DispatchLocationService : IDispatchLocationService
    {
        private readonly IDispatchLocationRepository _dispatchLocationRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IApplicationLogErrorRepository _applicationLogErrorRepository;
        public DispatchLocationService(IDispatchLocationRepository dispatchLocationRepository, IHttpContextAccessor httpContextAccessor, IApplicationLogErrorRepository applicationLogErrorRepository)
        {
            _dispatchLocationRepository = dispatchLocationRepository;
            _httpContextAccessor = httpContextAccessor;
            _applicationLogErrorRepository = applicationLogErrorRepository;
        }


        public async Task<CommonResultResponseDto<PaginatedList<DispatchLocationsResponseDto>>> GetAllDispatchLocations(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            var (dispatchLocations, total) = await _dispatchLocationRepository.GetAllDispatchLocations(filterModel, commonRequest, getSort);
            return CommonResultResponseDto<PaginatedList<DispatchLocationsResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<DispatchLocationsResponseDto>(dispatchLocations, total), 0);
        }

        public async Task<CommonResultResponseDto<CreateUpdateDispatchLocationResponseDto>> CreateUpdateDispatchLocation(CreateUpdateDispatchLocationRequestDto createUpdateDispatchLocationRequestDto)
        {
            var returnvalue = await _dispatchLocationRepository.IsExistDispatchLocation(createUpdateDispatchLocationRequestDto.LocationName, createUpdateDispatchLocationRequestDto.Id);
            if (returnvalue == true)
            {
                return CommonResultResponseDto<CreateUpdateDispatchLocationResponseDto>.Failure(new string[] { ActionStatusHelper.IsExistName }, null);
            }
            else
            {
                var dispatchLocation = await _dispatchLocationRepository.CreateUpdateDispatchLocation(createUpdateDispatchLocationRequestDto);

                if (dispatchLocation == 0)
                {
                    return CommonResultResponseDto<CreateUpdateDispatchLocationResponseDto>.Success(new string[] { ActionStatusHelper.Created }, null, 0);
                }
                else
                {
                    return CommonResultResponseDto<CreateUpdateDispatchLocationResponseDto>.Success(new string[] { ActionStatusHelper.Updated }, null, 0);
                }
            }
        }

        public async Task<CommonResultResponseDto<string>> DeleteDispatchLocation(int id)
        {
            bool result = await _dispatchLocationRepository.DeleteDispatchLocation(id);
            if (result)
            {
                return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Deleted }, null, 0);
            }
            else
            {
                return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.Error }, null);
            }
        }

        public async Task<CommonResultResponseDto<string>> UpdateIsBayStatus(UpdateIsBayStatusRequestDto updateIsBayStatusRequestDto)
        {
            var updateIsBayStatus = await _dispatchLocationRepository.UpdateIsBayStatus(updateIsBayStatusRequestDto);

            if (updateIsBayStatus == 0)
            {
                return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Updated }, null, 0);
            }

            else
            {
                return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.Error }, null);
            }
        }

        public async Task<CommonResultResponseDto<DispatchLocationRequestDto>> CallUrlsAccordingToType(DispatchLocationRequestDto dispatchLocation)
        {
            string clientIp = CustomAuthorizationMiddleWare.GetClientIPAddress(_httpContextAccessor.HttpContext);
            if (!string.IsNullOrEmpty(clientIp) && clientIp != "::1")
            {
                dispatchLocation.ClientIp = clientIp;
            }
            else
            {
                dispatchLocation.ClientIp = "internal ip";
            }

            var getLocation = await GetDispatchLocation(dispatchLocation);
            var action = "Dispatch Location Change - " + getLocation.Data.ChangedFlag;
            if (getLocation.Succeeded)
            {               
                var logMessage = getLocation.Data.DispatchName + " has changed " + getLocation.Data.ChangedFlag + " property of " + getLocation.Data.LocationName;
                await _applicationLogErrorRepository.AddLogDispatchAction(new DispatchActionLog(getLocation.Data.DispatchId, getLocation.Data.DispatchName, getLocation.Data.Id, getLocation.Data.LocationName, getLocation.Data.Code, action, logMessage, getLocation.Data.FullUrl, dispatchLocation.ResultMassage, getLocation.Data.LiveUrlMessage, getLocation.Data.BackupUrlMessage, getLocation.Data.ClientIp, getLocation.Data.BackUpUrl, true));
                return CommonResultResponseDto<DispatchLocationRequestDto>.Success(new string[] { ActionStatusHelper.Success }, dispatchLocation);
            }
            else
            {
                var logMessage = getLocation.Data.DispatchName + " could not change " + getLocation.Data.ChangedFlag + " property of " + getLocation.Data.LocationName;
                await _applicationLogErrorRepository.AddLogDispatchAction(new DispatchActionLog(getLocation.Data.DispatchId, getLocation.Data.DispatchName, getLocation.Data.Id, getLocation.Data.LocationName, getLocation.Data.Code, action, logMessage, getLocation.Data.FullUrl, getLocation.Errors[0].ToString(), getLocation.Data.LiveUrlMessage, getLocation.Data.BackupUrlMessage, getLocation.Data.ClientIp, getLocation.Data.BackUpUrl, true));
                return CommonResultResponseDto<DispatchLocationRequestDto>.Failure(new string[] { "Local ip not allowed!" }, null);
            }
        }
        #region Private
        private async Task<CommonResultResponseDto<DispatchLocationRequestDto>> GetDispatchLocation(DispatchLocationRequestDto dispatchLocation)
        {
            bool isLocal = LocalCheck.isLocal;

            DispatchUrlSetting dispatchUrlSetting = new DispatchUrlSetting();
            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponseLiveUrl = new HttpResponseMessage();
            HttpResponseMessage httpResponseBackUpUrl = new HttpResponseMessage();
            UrlCallReponse resultUrlCallBackup = new UrlCallReponse();
            UrlCallReponse resultUrlCallLive = new UrlCallReponse();

            if (!isLocal)
            {
                //var allowedIp = allowedIpDal.GetByIp(dispatchLocation.clientIp);
                //if (allowedIp == null)
                //{
                //    businessReturn.BusinessResult = false;
                //    businessReturn.ResultMessage = "Ip not allowed";
                //    businessReturn.Data = dispatchLocation;
                //    return businessReturn;
                //}

                dispatchLocation.DispatchName = await _dispatchLocationRepository.GetDispatchLocation(dispatchLocation.DispatchId);

                if (string.Equals(dispatchLocation.ChangedColumn, "isBackup", StringComparison.OrdinalIgnoreCase))
                {
                    dispatchLocation.ChangedFlag = "Is Backup";
                    dispatchUrlSetting = await _dispatchLocationRepository.GetBackUpAndLiveUrl(ConstantVariables.IS_BACKUP_PURPOSE);
                    var action = dispatchLocation.IsBackup ? 1 : 0;
                    var postfix = "?backup_dispatcher=" + dispatchLocation.Code.ToString() + "&action=" + action;

                    dispatchLocation.BackUpUrl = dispatchUrlSetting.BackUpUrl + postfix;
                    try
                    {
                        httpResponseBackUpUrl = await client.GetAsync(dispatchLocation.BackUpUrl);
                        var reponseContentBackUpUrl = httpResponseBackUpUrl.Content.ReadAsStringAsync();
                        var reponseContentJsonBackUpUrl = reponseContentBackUpUrl.Result;
                        resultUrlCallBackup = JsonConvert.DeserializeObject<UrlCallReponse>(reponseContentJsonBackUpUrl);
                    }
                    catch (Exception e)
                    {
                        resultUrlCallBackup.Status = "ERROR";
                        resultUrlCallBackup.Msg = "Could not get a valid Json response: " + e.Message;
                    }
                    dispatchLocation.BackupUrlMessage = resultUrlCallBackup.Status + " " + resultUrlCallBackup.Msg;

                    dispatchLocation.FullUrl = dispatchUrlSetting.LiveUrl + postfix;
                    try
                    {
                        httpResponseLiveUrl = await client.GetAsync(dispatchLocation.FullUrl);
                        var reponseContent = httpResponseLiveUrl.Content.ReadAsStringAsync();
                        var reponseContentJson = reponseContent.Result;
                        resultUrlCallLive = JsonConvert.DeserializeObject<UrlCallReponse>(reponseContentJson);
                    }
                    catch (Exception e)
                    {
                        resultUrlCallLive.Status = "ERROR";
                        resultUrlCallLive.Msg = "Could not get a valid Json response: " + e.Message;
                    }
                    dispatchLocation.LiveUrlMessage = resultUrlCallLive.Status + " " + resultUrlCallLive.Msg;
                }
                else if (string.Equals(dispatchLocation.ChangedColumn, "isDelay", StringComparison.OrdinalIgnoreCase))
                {
                    dispatchLocation.ChangedFlag = "Is Delay";
                    dispatchUrlSetting = await _dispatchLocationRepository.GetBackUpAndLiveUrl(ConstantVariables.IS_DELAY_PURPOSE);
                    var action = dispatchLocation.IsDelay ? 1 : 0;
                    var postfix = "?dispatcher=" + dispatchLocation.Code.ToString() + "&action=" + action;

                    dispatchLocation.BackUpUrl = dispatchUrlSetting.BackUpUrl + postfix;
                    try
                    {
                        httpResponseBackUpUrl = await client.GetAsync(dispatchLocation.BackUpUrl);
                        var reponseContentBackUpUrl = httpResponseBackUpUrl.Content.ReadAsStringAsync();
                        var reponseContentJsonBackUpUrl = reponseContentBackUpUrl.Result;
                        resultUrlCallBackup = JsonConvert.DeserializeObject<UrlCallReponse>(reponseContentJsonBackUpUrl);
                    }
                    catch (Exception e)
                    {
                        resultUrlCallBackup.Status = "ERROR";
                        resultUrlCallBackup.Msg = "Could not get a valid Json response: " + e.Message;
                    }
                    dispatchLocation.BackupUrlMessage = resultUrlCallBackup.Status + " " + resultUrlCallBackup.Msg;

                    dispatchLocation.FullUrl = dispatchUrlSetting.LiveUrl + postfix;
                    try
                    {
                        httpResponseLiveUrl = await client.GetAsync(dispatchLocation.FullUrl);
                        var reponseContent = httpResponseLiveUrl.Content.ReadAsStringAsync();
                        var reponseContentJson = reponseContent.Result;
                        resultUrlCallLive = JsonConvert.DeserializeObject<UrlCallReponse>(reponseContentJson);
                    }
                    catch (Exception e)
                    {
                        resultUrlCallLive.Status = "ERROR";
                        resultUrlCallLive.Msg = "Could not get a valid Json response: " + e.Message;
                    }
                    dispatchLocation.LiveUrlMessage = resultUrlCallLive.Status + " " + resultUrlCallLive.Msg;
                }
                else if (string.Equals(dispatchLocation.ChangedColumn, "isCoordinator", StringComparison.OrdinalIgnoreCase))
                {
                    dispatchLocation.ChangedFlag = "Is Coordinator";
                    dispatchUrlSetting = await _dispatchLocationRepository.GetBackUpAndLiveUrl(ConstantVariables.IS_COORDINATOR_PURPOSE);
                    var action = dispatchLocation.IsCoordinator ? 1 : 0;
                    var postfix = "?coordinator=" + dispatchLocation.Code.ToString() + "&action=" + action;

                    dispatchLocation.BackUpUrl = dispatchUrlSetting.BackUpUrl + postfix;
                    try
                    {
                        httpResponseBackUpUrl = await client.GetAsync(dispatchLocation.BackUpUrl);
                        var reponseContentBackUpUrl = httpResponseBackUpUrl.Content.ReadAsStringAsync();
                        var reponseContentJsonBackUpUrl = reponseContentBackUpUrl.Result;
                        resultUrlCallBackup = JsonConvert.DeserializeObject<UrlCallReponse>(reponseContentJsonBackUpUrl);
                    }
                    catch (Exception e)
                    {
                        resultUrlCallBackup.Status = "ERROR";
                        resultUrlCallBackup.Msg = "Could not get a valid Json response: " + e.Message;
                    }
                    dispatchLocation.BackupUrlMessage = resultUrlCallBackup.Status + " " + resultUrlCallBackup.Msg;

                    dispatchLocation.FullUrl = dispatchUrlSetting.LiveUrl + postfix;
                    try
                    {
                        httpResponseLiveUrl = await client.GetAsync(dispatchLocation.FullUrl);
                        var reponseContent = httpResponseLiveUrl.Content.ReadAsStringAsync();
                        var reponseContentJson = reponseContent.Result;
                        resultUrlCallLive = JsonConvert.DeserializeObject<UrlCallReponse>(reponseContentJson);
                    }
                    catch (Exception e)
                    {
                        resultUrlCallLive.Status = "ERROR";
                        resultUrlCallLive.Msg = "Could not get a valid Json response: " + e.Message;
                    }
                    dispatchLocation.LiveUrlMessage = resultUrlCallLive.Status + " " + resultUrlCallLive.Msg;
                }
                dispatchLocation.ResultMassage = $"Live Url: {resultUrlCallLive.Status} {resultUrlCallLive.Msg} - BackupUrl: {resultUrlCallBackup.Status} {resultUrlCallBackup.Msg}";
                return CommonResultResponseDto<DispatchLocationRequestDto>.Success(new string[] { ActionStatusHelper.Success }, dispatchLocation);
               
            }
            else
            {
                return CommonResultResponseDto<DispatchLocationRequestDto>.Failure(new string[] { "Local ip not allowed!" }, dispatchLocation);
            }
        }
        #endregion


    }
}
