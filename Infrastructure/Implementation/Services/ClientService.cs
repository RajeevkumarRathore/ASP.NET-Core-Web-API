using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Dtos;
using Application.Common.Helpers;
using Application.Common.Helpers.Constant;
using Application.Common.Response;
using Application.Handler.Header.Dtos;
using Common.Helper;
using Domain.Entities;
using DTO.Request.CallHistory;
using DTO.Request.ClientInfo;
using DTO.Response;
using DTO.Response.CallHistory;
using DTO.Response.Dashboard;
using Helper;
using Mapster;
using System.Text.RegularExpressions;

namespace Infrastructure.Implementation.Services
{
    public class ClientService:IClientService
    {
        private readonly IClientRepository _clientRepository ;
        private readonly IReportRepository _reportRepository ;
       

        public ClientService(IClientRepository clientRepository, IReportRepository reportRepository)
        {
            _clientRepository = clientRepository;
            _reportRepository = reportRepository;
            
        }
        #region dashboard


        public async Task<CommonResultResponseDto<List<GetCallsTypeDetailsResponseDto>>> GetCallsTypeDetails(DateTime startDate, DateTime endDate, bool isViewAll, string searchText)
        {
            var result = await _clientRepository.GetCallsTypeDetails(startDate, endDate, isViewAll, searchText);
            return CommonResultResponseDto<List<GetCallsTypeDetailsResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, result.Adapt<List<GetCallsTypeDetailsResponseDto>>());
        }
        public async Task<CommonResultResponseDto<List<GetNatureOfCallsDetailsResponseDto>>> GetNatureOfCallsDetails(DateTime startDate, DateTime endDate, bool isViewAll, string searchText)
        {
            var result = await _clientRepository.GetNatureOfCallsDetails(startDate, endDate, isViewAll, searchText);
            return CommonResultResponseDto<List<GetNatureOfCallsDetailsResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, result.Adapt<List<GetNatureOfCallsDetailsResponseDto>>());
        }
        public async Task<CommonResultResponseDto<List<GetPcrDetailsResponseDto>>> GetPcrDetails(DateTime startDate, DateTime endDate)
        {
            var result = await _clientRepository.GetPcrDetails(startDate, endDate);
            return CommonResultResponseDto<List<GetPcrDetailsResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, result.Adapt<List<GetPcrDetailsResponseDto>>());
        }
        public async Task<CommonResultResponseDto<List<GetCallVolumeDetailsResponseDto>>> GetCallVolumeDetails(DateTime startDate, DateTime endDate)
        {
            var result = await _clientRepository.GetCallVolumeDetails(startDate, endDate);
            return CommonResultResponseDto<List<GetCallVolumeDetailsResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, result.Adapt<List<GetCallVolumeDetailsResponseDto>>());
        }
        public async Task<CommonResultResponseDto<GetNightShiftDetailsResponseDto>> GetNightShiftDetails(DateTime todayDate)
        {
            var nightShiftResponse = new GetNightShiftDetailsResponseDto();
            List<ResNightShift> yesterdayRes = new();
            List<ResNightShift> todayRes = new();
            List<ResNightShift> tomorrowRes = new();
            var result = await _clientRepository.GetNightShiftDetails(todayDate);
            var yesterday = result.Yesterday.GroupBy(x => x.ScheduleName.Replace(" ", ""));
            var today = result.Today.GroupBy(x => x.ScheduleName.Replace(" ", ""));
            var tomorrow = result.Tomorrow.GroupBy(x => x.ScheduleName.Replace(" ", ""));

            foreach (var items in yesterday)
            {
                ResNightShift obj = new()
                {
                    ScheduleName = items.Key,
                    BadgeNumbers = new List<string>()
                };

                foreach (var item in items)
                {
                    if (item.BadgeNumber != "" && item.BadgeNumber != null)
                    {
                        obj.BadgeNumbers.Add(item.BadgeNumber);
                    }
                }

                yesterdayRes.Add(obj);
            }

            foreach (var items in today)
            {
                ResNightShift obj = new()
                {
                    ScheduleName = items.Key,
                    BadgeNumbers = new List<string>()
                };

                foreach (var item in items)
                {
                    if (item.BadgeNumber != "" && item.BadgeNumber != null)
                    {
                        obj.BadgeNumbers.Add(item.BadgeNumber);
                    }
                }

                todayRes.Add(obj);
            }

            foreach (var items in tomorrow)
            {
                ResNightShift obj = new()
                {
                    ScheduleName = items.Key,
                    BadgeNumbers = new List<string>()
                };

                foreach (var item in items)
                {
                    if (item.BadgeNumber != "" && item.BadgeNumber != null)
                    {
                        obj.BadgeNumbers.Add(item.BadgeNumber);
                    }
                }

                tomorrowRes.Add(obj);
            }
            nightShiftResponse.Yesterday.AddRange(yesterdayRes);
            nightShiftResponse.Today.AddRange(todayRes);
            nightShiftResponse.Tomorrow.AddRange(tomorrowRes);


            return CommonResultResponseDto<GetNightShiftDetailsResponseDto>.Success(new string[] { ActionStatusHelper.Success }, nightShiftResponse, 0);
        }

        public async Task<CommonResultResponseDto<IList<GetPcrSummaryDetailsResponseDto>>> GetPcrSummaryDetails(DateTime startDate, DateTime endDate)
        {
            var result = await _clientRepository.GetPcrSummaryDetails(startDate, endDate);
            return CommonResultResponseDto<IList<GetPcrSummaryDetailsResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, result.Adapt<List<GetPcrSummaryDetailsResponseDto>>());
        }
        public async Task<CommonResultResponseDto<List<GetReportDashboardCountsByDateResponseDto>>> GetReportDashboardCountsByDate(DateTime startDate, DateTime endDate)
        {
            var result = await _clientRepository.GetReportDashboardCountsByDate(startDate,endDate);
            return CommonResultResponseDto<List<GetReportDashboardCountsByDateResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, result.Adapt<List<GetReportDashboardCountsByDateResponseDto>>());
        }

        public async Task<CommonResultResponseDto<List<GetOpenCompletedPcrByBadgeNumberResponseDto>>> GetOpenCompletedPcrByBadgeNumber(string badgeNumber, bool isOpenPcr)
        {
            var result = await _clientRepository.GetOpenCompletedPcrByBadgeNumber(badgeNumber, isOpenPcr);
            return CommonResultResponseDto<List<GetOpenCompletedPcrByBadgeNumberResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, result.Adapt<List<GetOpenCompletedPcrByBadgeNumberResponseDto>>());
        }
        #endregion
        #region callhistory
        public async Task<CommonResultResponseDto<UpdateCallStatusRequestDto>> UpdateCallStatus(int clientId)
        {
            var brc = await _clientRepository.UpdateCallStatus(clientId);
            return CommonResultResponseDto<UpdateCallStatusRequestDto>.Success(new string[] { ActionStatusHelper.Success }, brc);
        }

        public async Task<CommonResultResponseDto<CallHistoryCountsResponseDto>> GetCallHistoryCounts()
        {
            var brc = await _clientRepository.GetCallHistoryCounts();
            return CommonResultResponseDto<CallHistoryCountsResponseDto>.Success(new string[] { ActionStatusHelper.Success }, brc);
        }

        public async Task<CommonResultResponseDto<PaginatedList<CallHistoryViewModel>>> GetCallHistory(GetCallHistoryViewModelRequestDto getCallHistoryViewModelRequest, bool hasReportsMenuPermission, ServerRowsRequest commonRequest, string filterModel, string getSort)
        {

            var currentUserRole =  getCallHistoryViewModelRequest.UserRoleID;

            hasReportsMenuPermission = false;
            var brcPermissions = await _clientRepository.GetRolePermissionByRoleId(currentUserRole);

            if (brcPermissions.Count > 0)
            {
                hasReportsMenuPermission = brcPermissions.Any(x => x.Name == PermissionConstants.MenuReports.View);
            }

            Users user = await _clientRepository.GetDispatcherInformationById(getCallHistoryViewModelRequest.currentLoggedInUser ?? 0);
            var dispatcher = await _clientRepository.GetDispatcherLogin();            

            var isLoggedInUserDispatcher = user?.Id == dispatcher?.UserId ? true : false;
            int? callHistoryPermissionHours = null;
            DateTime? dateParameterAccordingToUser;

            if (user?.SysRolesId != null)
            {
                var sysRoleResponse =await _clientRepository.GetRecordsBySysRolesId(user.SysRolesId);
                callHistoryPermissionHours = sysRoleResponse.CallHistoryPermissionHours;
                if (callHistoryPermissionHours == null)
                {
                    callHistoryPermissionHours = -4;
                }
                else
                {
                    callHistoryPermissionHours = -callHistoryPermissionHours;
                }
            }
            if (user?.SysRolesId == ConstantVariables.SYS_ROLES_ADMIN_ID || getCallHistoryViewModelRequest.fromCallHistoryTab == true || hasReportsMenuPermission)
            {
                dateParameterAccordingToUser = null;
            }
            else if (isLoggedInUserDispatcher)
            {
                dateParameterAccordingToUser = dispatcher.DispatchingFromTime.Value.AddHours((double)callHistoryPermissionHours);
            }
            else
            {
                dateParameterAccordingToUser = DateTime.Now.AddHours((double)callHistoryPermissionHours);
            }
            
            DateTime startDate = DateTime.Parse(getCallHistoryViewModelRequest.startDate);
            DateTime endDate = DateTime.Parse(getCallHistoryViewModelRequest.endDate);
            if (filterModel.Contains("datetime"))
            {
                Regex regex = new Regex(@"datetime\s*=\s*'([^']*)'");
                Match match = regex.Match(filterModel);

                if (match.Success)
                {
                    string originalDate = match.Groups[1].Value;
                    if (DateTime.TryParse(originalDate, out DateTime dateTime))
                    {
                        string formattedDate = dateTime.ToString("MM/dd/yyyy");
                        filterModel = regex.Replace(filterModel, $"Date = '{formattedDate}'");
                    }
                }
            }
            var (allCallHistory, total) = await _clientRepository.GetCallHistory(startDate, endDate,getCallHistoryViewModelRequest, dateParameterAccordingToUser, getCallHistoryViewModelRequest.isDispatchedCallsOnly, commonRequest,filterModel,getSort, getCallHistoryViewModelRequest.IsALSActivatedCallsOnly);
            allCallHistory.ForEach(y => y.Reports = string.Join(",", (y.Reports.Split(',').Select(x => Convert.ToString(x).Replace("KY", "K").Replace("Medic", "M").Trim()).Distinct().ToList())));
            var webUrl = Session.AccessingURL;
            if (user?.SysRolesId != ConstantVariables.SYS_ROLES_ADMIN_ID)
            {
                foreach (var item in allCallHistory)
                {
                    if ((item.CreatedBy == user.Username && (DateTime.Now - item.dispositionDate)?.TotalMinutes < 10))
                    {
                        if (item.ExternalFileName != null)
                        {
                            item.ExternalFilePath = webUrl + AppSettingsProvider.VoiceMessagePath.VirtualPath + item.ExternalFileName;
                        }                        
                    }
                }
            }
            else
            {
                foreach (var item in allCallHistory)
                {                   
                        if (item.ExternalFileName != null)
                        {
                            item.ExternalFilePath = webUrl + AppSettingsProvider.VoiceMessagePath.VirtualPath + item.ExternalFileName;
                        }                    
                }
            }
             return CommonResultResponseDto<PaginatedList<CallHistoryViewModel>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<CallHistoryViewModel>(allCallHistory, total), 0);
        }

        public async Task<CommonResultResponseDto<PaginatedList<GetCallHistoryShabbosResponseDto>>> GetCallHistoryShabbos(GetCallHistoryViewModelRequestDto getCallHistoryViewModelRequest, bool hasReportsMenuPermission, ServerRowsRequest commonRequest, string filterModel, string getSort)
        {
            DateTime startDate = DateTime.Parse(getCallHistoryViewModelRequest.startDate);
            DateTime endDate = DateTime.Parse(getCallHistoryViewModelRequest.endDate);
            if (filterModel.Contains("datetime"))
            {
                Regex regex = new Regex(@"datetime\s*=\s*'([^']*)'");
                Match match = regex.Match(filterModel);

                if (match.Success)
                {
                    string originalDate = match.Groups[1].Value;
                    if (DateTime.TryParse(originalDate, out DateTime dateTime))
                    {
                        string formattedDate = dateTime.ToString("MM/dd/yyyy");
                        filterModel = regex.Replace(filterModel, $"Date = '{formattedDate}'");
                    }
                }
            }
            var (allCallHistoryShabbos, total) = await _clientRepository.GetCallHistoryShabbos(startDate, endDate, getCallHistoryViewModelRequest, getCallHistoryViewModelRequest.DateParameterAccordingToUser, getCallHistoryViewModelRequest.isDispatchedCallsOnly, commonRequest, filterModel, getSort);
            allCallHistoryShabbos.ForEach(item =>
            {
                item.members.ForEach(member =>
                    member.Reports = string.Join(",", member.Reports.Split(',')
                        .Select(report => report.Replace("KY", "K").Replace("Medic", "M").Trim()).Distinct().ToList())
                );
            });
            return CommonResultResponseDto<PaginatedList<GetCallHistoryShabbosResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<GetCallHistoryShabbosResponseDto>(allCallHistoryShabbos, total), 0);
        }
        #endregion


        public async Task<bool> CheckAndApplyCallStatusChanges(int clientId, string currentUsername)
        {
            var callStatusChanged = false;
            var clientData = await _clientRepository.GetActiveClients(clientId);
            var clientDto = clientData?.FirstOrDefault();
            if (clientDto != null && !clientDto.isCallStatusManual)
            {
                var callStatus = clientDto.call_status;
                var mappedCallStatus = clientDto.mappedCallStatus;

                if (clientDto.AllMemberSet?.Any() == true)
                {
                    var alsMembers = clientDto.AllMemberSet.Where(x => x.memberExpertises.Any(x => x.ExpertisesId == 1)).ToList();

                    var hasTrMember = clientDto.AllMemberSet.Any(x => x.is_Transport == true);

                    var hasAlsTransportMember = alsMembers.Any(x => x.is_Transport == true);

                    var hasBusMembers = clientDto.AllMemberSet.Any(x => x.isBus == true);

                    callStatus = ConstantVariables.CALL_STATUS_MEMBERASSIGNED;
                    mappedCallStatus = ConstantVariables.MAPPED_CALL_STATUS_UNITS_DISPATCHED;

                    if (alsMembers.Count() > 0)
                    {
                        mappedCallStatus = ConstantVariables.MAPPED_CALL_STATUS_MEDICS_DISPATCHED;
                    }

                    if (hasBusMembers)
                    {
                        mappedCallStatus = ConstantVariables.MAPPED_CALL_STATUS_BUS_DISPATCHED;
                    }

                    if (!string.IsNullOrWhiteSpace(clientDto.onSceneTime))
                    {
                        callStatus = ConstantVariables.CALL_STATUS_ONSCENE;
                        mappedCallStatus = ConstantVariables.MAPPED_CALL_STATUS_ON_SCENE;
                    }

                    if (hasTrMember && clientDto.hospitalId > 0 && !string.IsNullOrWhiteSpace(clientDto.fromSceneTime))
                    {
                        callStatus = ConstantVariables.CALL_STATUS_FROMSCENE;
                        mappedCallStatus = ConstantVariables.MAPPED_CALL_STATUS_BUS_BLS_TO_HOSPITAL;
                    }

                    if (hasAlsTransportMember && clientDto.hospitalId > 0 && !string.IsNullOrWhiteSpace(clientDto.fromSceneTime))
                    {
                        callStatus = ConstantVariables.CALL_STATUS_ALSTRANSPORT;
                        mappedCallStatus = ConstantVariables.MAPPED_CALL_STATUS_BUS_ALS_TO_HOSPITAL;
                    }

                    if (!string.IsNullOrWhiteSpace(clientDto.destinationTime))
                    {
                        callStatus = ConstantVariables.CALL_STATUS_FROMSCENE;
                        mappedCallStatus = ConstantVariables.MAPPED_CALL_STATUS_OUT_AT_HOSPITAL;
                    }

                    if (!string.IsNullOrWhiteSpace(clientDto.inServiceTime))
                    {
                        callStatus = ConstantVariables.CALL_STATUS_FROMSCENE;
                        mappedCallStatus = ConstantVariables.MAPPED_CALL_STATUS_BUS_AVAILABLE_AGAIN;
                    }
                }
                else
                {
                    if (callStatus == ConstantVariables.CALL_STATUS_ATTENDED)
                    {
                        callStatus = ConstantVariables.CALL_STATUS_ATTENDED;
                        mappedCallStatus = ConstantVariables.MAPPED_CALL_STATUS_COMMITTED;
                    }
                    else
                    {
                        callStatus = ConstantVariables.CALL_STATUS_UNATTENDED;
                        mappedCallStatus = ConstantVariables.MAPPED_CALL_STATUS_CALL_RECEIVED;
                    }
                }

                if (callStatus != clientDto.call_status || mappedCallStatus != clientDto.mappedCallStatus)
                {
                    Clients client = new Clients();
                    client = await _reportRepository.GetClientById(clientId);

                    client.call_status = callStatus;
                    client.MappedCallStatus = mappedCallStatus;

                    await _reportRepository.UpdateClientById(client);
                    callStatusChanged = true;
                    if (!string.Equals(mappedCallStatus, ConstantVariables.MAPPED_CALL_STATUS_CALL_RECEIVED, StringComparison.OrdinalIgnoreCase))
                    {
                        await _clientRepository.AddAsyncVoid(new ClientActivityLog(clientId, (int)Domain.Enums.AppEnums.ClientActivityLogType.CallStatusChanged, $"Status was changed from {clientDto.mappedCallStatus} to {mappedCallStatus} by {currentUsername}."));
                    }
                }
            }
            return callStatusChanged;
        }

        public async Task<CommonResultResponseDto<IList<CallHistoryViewModel>>> GetWeeklyReportData(DateTime startDate, DateTime endDate, string searchText, bool isDispatchedCallsOnly, bool isALSActivatedCallsOnly)
        {
            var result = await _clientRepository.GetWeeklyReportData(startDate, endDate,searchText,isDispatchedCallsOnly,isALSActivatedCallsOnly);
            return CommonResultResponseDto<IList<CallHistoryViewModel>>.Success(new string[] { ActionStatusHelper.Success }, result.Adapt<IList<CallHistoryViewModel>>());
        }
    }
}
