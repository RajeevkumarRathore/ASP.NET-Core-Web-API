using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Helpers;
using Domain.Entities;
using DTO.Request.Report;
using DTO.Request.Settings;
using DTO.Response;
using DTO.Response.Report;
using DTO.Response.Settings;
using Helper;
using Newtonsoft.Json;
using System.Net;
using System.Xml.Serialization;
using System.Xml;
using RestSharp;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Implementation.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly ISettingsRepository _settingsRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IConfiguration _configuration;

        public SettingsService(ISettingsRepository settingsRepository, IMemberRepository memberRepository, IConfiguration configuration)
        {
            _settingsRepository = settingsRepository;
            _memberRepository = memberRepository;
            _configuration = configuration;
        }
        public async Task<CommonResultResponseDto<CreativeSettingsResponseDto>> GetAllCreativeSettings()
        {
            Setting BRC = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_CREATIVE_OPTIONS);
            if (BRC != null && BRC.Id != 0)
            {
                var creativeOptions = JsonConvert.DeserializeObject<CreativeSettingsResponseDto>(BRC.JsonProperties);
                return CommonResultResponseDto<CreativeSettingsResponseDto>.Success(new string[] { ActionStatusHelper.Success }, creativeOptions, 0);
            }
            else
            {
                return CommonResultResponseDto<CreativeSettingsResponseDto>.Failure(new string[] { ActionStatusHelper.Error }, null);
            }
        }

        public async Task<CommonResultResponseDto<Setting>> UpdateJsonProperty(UpdateJsonPropertyRequestDto updateJsonPropertyRequestDto)
        {
            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_CREATIVE_OPTIONS);

            if (brcSettings != null && brcSettings.Id != 0)
            {
                brcSettings.JsonProperties = JsonConvert.SerializeObject(updateJsonPropertyRequestDto);

                var jsonProperty = await _settingsRepository.UpdateJsonProperty(brcSettings.Id, brcSettings.JsonProperties);
                return CommonResultResponseDto<Setting>.Success(new string[] { ActionStatusHelper.Success }, jsonProperty, 0);
            }

            return CommonResultResponseDto<Setting>.Failure(new string[] { ActionStatusHelper.Error }, null);
        }

        public async Task<CommonResultResponseDto<string>> UpdateCreativePbxStatus(UpdateCreativePbxStatusRequestDto updateCreativePbxStatusRequestDto)
        {
            var urlToCall = string.Empty;
            var creativePbxUrl = await _settingsRepository.GetBackUpAndLiveUrl(ConstantVariables.CREATIVE_PBX);

            if (updateCreativePbxStatusRequestDto.CreativePbx1 != null)
            {
                urlToCall = updateCreativePbxStatusRequestDto.CreativePbx1 == true ? creativePbxUrl.LiveUrl + "1" : creativePbxUrl.LiveUrl + "0";
            }
            else if (updateCreativePbxStatusRequestDto.CreativePbx2 != null)
            {
                urlToCall = updateCreativePbxStatusRequestDto.CreativePbx2 == true ? creativePbxUrl.BackUpUrl + "1" : creativePbxUrl.BackUpUrl + "0";
            }

            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponse;
            UrlCallReponseDto resultUrlCall = new UrlCallReponseDto();

            httpResponse = await client.GetAsync(urlToCall);
            var reponseContent = httpResponse.Content.ReadAsStringAsync();
            var reponseContentJson = reponseContent.Result;

            resultUrlCall = JsonConvert.DeserializeObject<UrlCallReponseDto>(reponseContentJson);
            if (resultUrlCall.Status == "OK")
            {
                return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Success }, null, 0);
            }
            else
            {
                return CommonResultResponseDto<string>.Failure(new string[] { "Failed to update the status!" }, null);
            }
        }

        public async Task<CommonResultResponseDto<string>> UpdateDatavancedPbxStatus(UpdateDatavancedPbxStatusRequestDto updateDatavancedPbxStatusRequestDto)
        {
            var urlToCall = string.Empty;
            var datavancedPbxUrl = await _settingsRepository.GetBackUpAndLiveUrl(ConstantVariables.DATAVANCED_PBX);

            if (updateDatavancedPbxStatusRequestDto.DatavancedPbx1 != null)
            {
                urlToCall = updateDatavancedPbxStatusRequestDto.DatavancedPbx1 == true ? datavancedPbxUrl.LiveUrl + "1" : datavancedPbxUrl.LiveUrl + "0";
            }
            else if (updateDatavancedPbxStatusRequestDto.DatavancedPbx2 != null)
            {
                urlToCall = updateDatavancedPbxStatusRequestDto.DatavancedPbx2 == true ? datavancedPbxUrl.BackUpUrl + "1" : datavancedPbxUrl.BackUpUrl + "0";
            }

            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponse;
            UrlCallReponseDto resultUrlCall = new UrlCallReponseDto();

            httpResponse = await client.GetAsync(urlToCall);
            var reponseContent = httpResponse.Content.ReadAsStringAsync();
            var reponseContentJson = reponseContent.Result;
            resultUrlCall = JsonConvert.DeserializeObject<UrlCallReponseDto>(reponseContentJson);
            if (resultUrlCall.Status == "OK")
            {
                return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Success }, null, 0);
            }
            else
            {
                return CommonResultResponseDto<string>.Failure(new string[] { "Failed to update the status!" }, null);
            }
        }

        public async Task<CommonResultResponseDto<DispatchAlertResponseDto>> GetDispatchDelay()
        {
            Setting BRC = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_DISPATCH_ALERT);            
            if (BRC != null && BRC.Id != 0)
            {
                var dispatchAlertDto = JsonConvert.DeserializeObject<DispatchAlertResponseDto>(BRC.JsonProperties);
                return CommonResultResponseDto<DispatchAlertResponseDto>.Success(new string[] { ActionStatusHelper.Success }, dispatchAlertDto, 0);
            }
            else
            {
                return CommonResultResponseDto<DispatchAlertResponseDto>.Failure(new string[] { ActionStatusHelper.Error }, null);
            }
        }

        public async Task<CommonResultResponseDto<Setting>> UpdateDispatchAlertSettings(UpdateDispatchAlertSettingsRequestDto updateDispatchAlertSettingsRequestDto)
        {
            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_DISPATCH_ALERT);

            var setting = brcSettings;
            var dispatchAlertJson = JsonConvert.DeserializeObject<UpdateDispatchAlertSettingsRequestDto>(setting.JsonProperties);

            updateDispatchAlertSettingsRequestDto.StartingDelay *= 60000; //convert to miliseconds
            updateDispatchAlertSettingsRequestDto.CountDown *= 60000;
            updateDispatchAlertSettingsRequestDto.StartingDelayMonitor *= 60000;

            dispatchAlertJson = updateDispatchAlertSettingsRequestDto;

            setting.JsonProperties = JsonConvert.SerializeObject(dispatchAlertJson);

            var jsonProperty = await _settingsRepository.UpdateJsonProperty(brcSettings.Id, brcSettings.JsonProperties);
            return CommonResultResponseDto<Setting>.Success(new string[] { ActionStatusHelper.Success }, jsonProperty, 0);
        }

        public async Task<CommonResultResponseDto<Setting>> UpdateAutoDismissCallSettings(UpdateAutoDismissCallSettingsRequestDto updateAutoDismissCallSettingsRequestDto)
        {
            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_AUTO_DISMISS_CALL);
            var autoDismissCall = new UpdateAutoDismissCallSettingsRequestDto();

            var setting = brcSettings;
            if (setting != null)
            {
                autoDismissCall = JsonConvert.DeserializeObject<UpdateAutoDismissCallSettingsRequestDto>(setting.JsonProperties);
            }
            else
            {
                setting = new Setting();
            }

            autoDismissCall.DismissDelay = updateAutoDismissCallSettingsRequestDto.DismissDelay * 60000; //convert to miliseconds
            setting.JsonProperties = JsonConvert.SerializeObject(autoDismissCall);
            setting.SettingName = ConstantVariables.SETTINGS_AUTO_DISMISS_CALL;

            var callSettings = await _settingsRepository.UpdateAutoDismissCallSettings(setting);
            return CommonResultResponseDto<Setting>.Success(new string[] { ActionStatusHelper.Success }, callSettings, 0);
        }

        public async Task<CommonResultResponseDto<Setting>> UpdateEnableDisableAutoDismissCallSwitch(bool isEnabled)
        {
            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_AUTO_DISMISS_CALL);
            var autoDismissCall = new UpdateAutoDismissCallSettingsRequestDto();

            var setting = brcSettings;
            if (setting != null)
            {
                autoDismissCall = JsonConvert.DeserializeObject<UpdateAutoDismissCallSettingsRequestDto>(setting.JsonProperties);
            }
            else
            {
                setting = new Setting();
            }

            autoDismissCall.IsEnabled = isEnabled;

            setting.JsonProperties = JsonConvert.SerializeObject(autoDismissCall);
            setting.SettingName = ConstantVariables.SETTINGS_AUTO_DISMISS_CALL;

            var callSettings = await _settingsRepository.UpdateAutoDismissCallSettings(setting);
            return CommonResultResponseDto<Setting>.Success(new string[] { ActionStatusHelper.Success }, callSettings, 0);
        }

        public async Task<CommonResultResponseDto<string>> DismissAllActiveCalls()
        {
            var callsToDismiss = await _settingsRepository.DismissAllActiveCalls();
            if (callsToDismiss != null)
            {
                return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Success }, callsToDismiss, 0);
            }
            else
            {
                return CommonResultResponseDto<string>.Failure(new string[] { "No calls found to dismiss!" }, null);
            }
        }

        public async Task<CommonResultResponseDto<FontSizeSettingResponseDto>> GetClientInfoPageFontSizeSetting()
        {
            Setting BRC = new Setting();
            var getAgencies = _configuration["Agencies"];
            if (getAgencies == ConstantAgencies.Test)
            {
                 BRC = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_HOMEPAGE_FONT_SETTINGS);
            }
            else if(getAgencies == ConstantAgencies.CentralJersey)
            {
                 BRC = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_CLIENTINFO_FONT_SIZE);
            }
            if (BRC != null && BRC.Id != 0)
            {
                var fontSizeSettingDto = JsonConvert.DeserializeObject<FontSizeSettingResponseDto>(BRC.JsonProperties);
                return CommonResultResponseDto<FontSizeSettingResponseDto>.Success(new string[] { ActionStatusHelper.Success }, fontSizeSettingDto, 0);
            }
            else
            {
                return CommonResultResponseDto<FontSizeSettingResponseDto>.Failure(new string[] { ActionStatusHelper.Error }, null);
            }
        }

        public async Task<CommonResultResponseDto<Setting>> UpdateClientInfoPageFontSizeSettings(UpdateClientInfoPageFontSizeSettingsRequestDto updateAutoDismissCallSettingsRequestDto)
        {
            Setting brcSettings = new Setting();
            var getAgencies = _configuration["Agencies"];
            if (getAgencies == ConstantAgencies.Test)
            {
                 brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_HOMEPAGE_FONT_SETTINGS);
            }
            else if(getAgencies == ConstantAgencies.CentralJersey)
            {
                 brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_CLIENTINFO_FONT_SIZE);
            }
            

            var setting = brcSettings;
            if (brcSettings != null && brcSettings.Id != 0)
            {
                FontSizeSettingResponseDto fontSizeSetting = JsonConvert.DeserializeObject<FontSizeSettingResponseDto>(setting.JsonProperties);

                fontSizeSetting.LocationFontSize = updateAutoDismissCallSettingsRequestDto.LocationFontSize;
                fontSizeSetting.LocationFontWeight = updateAutoDismissCallSettingsRequestDto.LocationFontWeight;
                fontSizeSetting.CallTypeFontSize = updateAutoDismissCallSettingsRequestDto.CallTypeFontSize;
                fontSizeSetting.CallTypeFontWeight = updateAutoDismissCallSettingsRequestDto.CallTypeFontWeight;
                fontSizeSetting.PatientInfoFontSize = updateAutoDismissCallSettingsRequestDto.PatientInfoFontSize;
                fontSizeSetting.PatientInfoFontWeight = updateAutoDismissCallSettingsRequestDto.PatientInfoFontWeight;
                fontSizeSetting.StatusFontSize = updateAutoDismissCallSettingsRequestDto.StatusFontSize;
                fontSizeSetting.StatusFontWeight = updateAutoDismissCallSettingsRequestDto.StatusFontWeight;
                fontSizeSetting.DispositionFontSize = updateAutoDismissCallSettingsRequestDto.DispositionFontSize;
                fontSizeSetting.DispositionFontWeight = updateAutoDismissCallSettingsRequestDto.DispositionFontWeight;
                fontSizeSetting.ClientCardNameFontSize = updateAutoDismissCallSettingsRequestDto.ClientCardNameFontSize;
                fontSizeSetting.ClientCardNameFontWeight = updateAutoDismissCallSettingsRequestDto.ClientCardNameFontWeight;
                fontSizeSetting.ClientCardPhoneAndAddressFontSize = updateAutoDismissCallSettingsRequestDto.ClientCardPhoneAndAddressFontSize;
                fontSizeSetting.ClientCardPhoneAndAddressFontWeight = updateAutoDismissCallSettingsRequestDto.ClientCardPhoneAndAddressFontWeight;
                fontSizeSetting.ClientCardMembersFontSize = updateAutoDismissCallSettingsRequestDto.ClientCardMembersFontSize;
                fontSizeSetting.ClientCardMembersFontWeight = updateAutoDismissCallSettingsRequestDto.ClientCardMembersFontWeight;
                fontSizeSetting.FontSize = updateAutoDismissCallSettingsRequestDto.FontSize;
                fontSizeSetting.FontWeight = updateAutoDismissCallSettingsRequestDto.FontWeight;

                setting.JsonProperties = JsonConvert.SerializeObject(fontSizeSetting);
            }
            else
            {
                setting.JsonProperties = JsonConvert.SerializeObject(updateAutoDismissCallSettingsRequestDto);
                setting.SettingName = ConstantVariables.SETTINGS_HOMEPAGE_FONT_SETTINGS;
            }

            var result = await _settingsRepository.UpdateAutoDismissCallSettings(setting);
            return CommonResultResponseDto<Setting>.Success(new string[] { ActionStatusHelper.Success }, result, 0);
        }

        public async Task<CommonResultResponseDto<OverwriteAddressPopupResponseDto>> GetOverwriteAddressPopupSettings()
        {
            OverwriteAddressPopupResponseDto brc = new OverwriteAddressPopupResponseDto();

            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_OVERWRITE_ADDRESS);

            if (brcSettings != null)
            {
                var setting = JsonConvert.DeserializeObject<OverwriteAddressPopupResponseDto>(brcSettings.JsonProperties);
                return CommonResultResponseDto<OverwriteAddressPopupResponseDto>.Success(new string[] { ActionStatusHelper.Success }, setting, 0);
            }

            return CommonResultResponseDto<OverwriteAddressPopupResponseDto>.Success(new string[] { ActionStatusHelper.Success }, brc, 0);
        }

        public async Task<CommonResultResponseDto<Setting>> UpdateEnableDisableOverwriteAddressPopupSwitch(bool isEnabled)
        {
            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_OVERWRITE_ADDRESS);
            var overwriteAddress = new OverwriteAddressPopupResponseDto();

            var setting = brcSettings;
            if (setting != null)
            {
                overwriteAddress = JsonConvert.DeserializeObject<OverwriteAddressPopupResponseDto>(setting.JsonProperties);
            }
            else
            {
                setting = new Setting();
            }

            overwriteAddress.IsEnabled = isEnabled;

            setting.JsonProperties = JsonConvert.SerializeObject(overwriteAddress);
            setting.SettingName = ConstantVariables.SETTINGS_OVERWRITE_ADDRESS;

            var popupSwitch = await _settingsRepository.UpdateAutoDismissCallSettings(setting);
            return CommonResultResponseDto<Setting>.Success(new string[] { ActionStatusHelper.Success }, popupSwitch, 0);
        }

        public async Task<CommonResultResponseDto<AllowToTransferCallResponseDto>> GetAllowToTransferCallSettings()
        {
            AllowToTransferCallResponseDto brc = new AllowToTransferCallResponseDto();

            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_ALLOW_TO_TRANSFER_CALL);

            if (brcSettings != null)
            {
                var setting = JsonConvert.DeserializeObject<AllowToTransferCallResponseDto>(brcSettings.JsonProperties);
                return CommonResultResponseDto<AllowToTransferCallResponseDto>.Success(new string[] { ActionStatusHelper.Success }, setting, 0);
            }

            return CommonResultResponseDto<AllowToTransferCallResponseDto>.Success(new string[] { ActionStatusHelper.Success }, brc, 0);
        }

        public async Task<CommonResultResponseDto<Setting>> UpdateAllowToTransferCallSwitch(bool isEnabled)
        {
            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_ALLOW_TO_TRANSFER_CALL);
            AllowToTransferCallResponseDto allowToTransferCall = new AllowToTransferCallResponseDto();

            var setting = brcSettings;
            if (setting != null)
            {
                allowToTransferCall = JsonConvert.DeserializeObject<AllowToTransferCallResponseDto>(setting.JsonProperties);
            }
            else
            {
                setting = new Setting();
            }

            allowToTransferCall.IsEnabled = isEnabled;

            setting.JsonProperties = JsonConvert.SerializeObject(allowToTransferCall);
            setting.SettingName = ConstantVariables.SETTINGS_ALLOW_TO_TRANSFER_CALL;

            var callSwitch = await _settingsRepository.UpdateAutoDismissCallSettings(setting);
            return CommonResultResponseDto<Setting>.Success(new string[] { ActionStatusHelper.Success }, callSwitch, 0);
        }

        public async Task<CommonResultResponseDto<List<QuotaEntry>>> GetSummaryQuotaSettings()
        {
            var setting = new List<QuotaEntry>();

            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_SUMMARY_QUOTA_SETTINGS);

            if (brcSettings != null)
            {
                setting = JsonConvert.DeserializeObject<List<QuotaEntry>>(brcSettings.JsonProperties);
                return CommonResultResponseDto<List<QuotaEntry>>.Success(new string[] { ActionStatusHelper.Success }, setting, 0);
            }
            return CommonResultResponseDto<List<QuotaEntry>>.Success(new string[] { ActionStatusHelper.Success }, setting, 0);
        }

        public async Task<CommonResultResponseDto<Setting>> SaveSummaryQuotaSettings(SaveSummaryQuotaSettingRequestDto saveSummaryQuotaSettingRequestDto)
        {
            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_SUMMARY_QUOTA_SETTINGS);
            var setting = brcSettings;

            string jsonString = JsonConvert.SerializeObject(saveSummaryQuotaSettingRequestDto.QuotaReq);

            if (setting == null)
            {
                setting = new Setting();
            }

            setting.JsonProperties = jsonString;
            setting.SettingName = ConstantVariables.SETTINGS_SUMMARY_QUOTA_SETTINGS;

            var summaryQuotaSettings = await _settingsRepository.UpdateAutoDismissCallSettings(setting);
            return CommonResultResponseDto<Setting>.Success(new string[] { ActionStatusHelper.Success }, summaryQuotaSettings, 0);
        }

        public async Task<CommonResultResponseDto<JsonProperties>> GetNotificationMessageValidTimeSetting()
        {

            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_MESSAGE_VALID_UNTIL);

            var setting = JsonConvert.DeserializeObject<JsonProperties>(brcSettings.JsonProperties);
            return CommonResultResponseDto<JsonProperties>.Success(new string[] { ActionStatusHelper.Success }, setting, 0);
        }

        public async Task<CommonResultResponseDto<Setting>> UpdateNotificationValidTimeSetting(UpdateNotificationValidTimeSettingRequestDto updateNotificationValidTimeSettingRequestDto)
        {
            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_MESSAGE_VALID_UNTIL);

            var setting = brcSettings;
            var replyTimeOutJson = JsonConvert.DeserializeObject<UpdateNotificationValidTimeSettingRequestDto>(setting.JsonProperties);

            updateNotificationValidTimeSettingRequestDto.ReplyTimeOut *= 60000; //convert to miliseconds

            replyTimeOutJson = updateNotificationValidTimeSettingRequestDto;

            setting.JsonProperties = JsonConvert.SerializeObject(replyTimeOutJson);

            var jsonProperty = await _settingsRepository.UpdateJsonProperty(brcSettings.Id, brcSettings.JsonProperties);
            return CommonResultResponseDto<Setting>.Success(new string[] { ActionStatusHelper.Success }, jsonProperty, 0);
        }

        public async Task<CommonResultResponseDto<CountyCallsResponseDto>> GetCountyCallsSetting()
        {
            Setting BRC = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_COUNTY_CALLS);
            if (BRC != null && BRC.Id != 0)
            {
                var countyCallsSetting = JsonConvert.DeserializeObject<CountyCallsResponseDto>(BRC.JsonProperties);
                return CommonResultResponseDto<CountyCallsResponseDto>.Success(new string[] { ActionStatusHelper.Success }, countyCallsSetting, 0);
            }
            else
            {
                return CommonResultResponseDto<CountyCallsResponseDto>.Failure(new string[] { ActionStatusHelper.Error}, null);
            }
        }

        public async Task<CommonResultResponseDto<Setting>> UpdateCountyCallsStatus(UpdateCountyCallsStatusRequestDto updateCountyCallsStatusRequestDto)
        {
            Setting setting = new Setting();
            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_COUNTY_CALLS);
            UpdateCountyCallsStatusRequestDto countyCallsSetting = new UpdateCountyCallsStatusRequestDto();

            if (brcSettings != null && brcSettings.Id != 0)
            {
                setting = brcSettings;
                countyCallsSetting = JsonConvert.DeserializeObject<UpdateCountyCallsStatusRequestDto>(setting.JsonProperties);

                countyCallsSetting.CountyCalls = updateCountyCallsStatusRequestDto.CountyCalls;

                setting.JsonProperties = JsonConvert.SerializeObject(countyCallsSetting);
            }
            else
            {


                countyCallsSetting.CountyCalls = updateCountyCallsStatusRequestDto.CountyCalls;
                setting.JsonProperties = JsonConvert.SerializeObject(countyCallsSetting);

                setting.SettingName = ConstantVariables.SETTINGS_COUNTY_CALLS;
            }


            CountyCallsSettingResponseDto.CountyCallsEnabled = updateCountyCallsStatusRequestDto.CountyCalls;
            CountyCallsSettingResponseDto.IsSettingReadFromDb = true;

            var callsStatus = await _settingsRepository.UpdateAutoDismissCallSettings(setting);
            return CommonResultResponseDto<Setting>.Success(new string[] { ActionStatusHelper.Success }, callsStatus, 0);
        }

        public async Task<CommonResultResponseDto<NotificationPopupResponseDto>> GetNotificationPopupSetting()
        {
            Setting BRC = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_NOTIFICATION_POPUP_HOVER);
            if (BRC != null && BRC.Id != 0)
            {
                var notificationPopup = JsonConvert.DeserializeObject<NotificationPopupResponseDto>(BRC.JsonProperties);
                return CommonResultResponseDto<NotificationPopupResponseDto>.Success(new string[] { ActionStatusHelper.Success }, notificationPopup, 0);
            }
            else
            {
                return CommonResultResponseDto<NotificationPopupResponseDto>.Failure(new string[] { ActionStatusHelper.Error }, null);
            }
        }

        public async Task<CommonResultResponseDto<Setting>> UpdateNotificationPopupStatus(UpdateNotificationPopupStatusRequestDto updateNotificationPopupStatusRequestDto)
        {
            Setting setting = new Setting();
            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_NOTIFICATION_POPUP_HOVER);
            UpdateNotificationPopupStatusRequestDto notificationPopup = new UpdateNotificationPopupStatusRequestDto();

            if (brcSettings != null && brcSettings.Id != 0)
            {
                setting = brcSettings;
                notificationPopup = JsonConvert.DeserializeObject<UpdateNotificationPopupStatusRequestDto>(setting.JsonProperties);

                notificationPopup.IsEnabled = updateNotificationPopupStatusRequestDto.IsEnabled;

                setting.JsonProperties = JsonConvert.SerializeObject(notificationPopup);
            }
            else
            {

                notificationPopup.IsEnabled = updateNotificationPopupStatusRequestDto.IsEnabled;
                setting.JsonProperties = JsonConvert.SerializeObject(notificationPopup);

                setting.SettingName = ConstantVariables.SETTINGS_NOTIFICATION_POPUP_HOVER;
            }

            var popupStatus = await _settingsRepository.UpdateAutoDismissCallSettings(setting);
            return CommonResultResponseDto<Setting>.Success(new string[] { ActionStatusHelper.Success }, popupStatus, 0);
        }

        public async Task<CommonResultResponseDto<FireDistrictPopupSettingResponseDto>> GetFireDistrictPopupSetting()
        {
            Setting BRC = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_FIRE_DISTRICT_POPUP);
            if (BRC != null && BRC.Id != 0)
            {
                var fireDistrictPopupSetting = JsonConvert.DeserializeObject<FireDistrictPopupSettingResponseDto>(BRC.JsonProperties);
                return CommonResultResponseDto<FireDistrictPopupSettingResponseDto>.Success(new string[] { ActionStatusHelper.Success }, fireDistrictPopupSetting, 0);
            }
            else
            {
                return CommonResultResponseDto<FireDistrictPopupSettingResponseDto>.Failure(new string[] { ActionStatusHelper.Error }, null);
            }
        }

        public async Task<CommonResultResponseDto<Setting>> UpdateFireDistrictPopupStatus(UpdateFireDistrictPopupStatusRequestDto updateFireDistrictPopupStatusRequestDto)
        {
            Setting setting = new Setting();
            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_FIRE_DISTRICT_POPUP);
            UpdateFireDistrictPopupStatusRequestDto fireDistrictPopup = new UpdateFireDistrictPopupStatusRequestDto();

            if (brcSettings != null && brcSettings.Id != 0)
            {
                setting = brcSettings;
                fireDistrictPopup = JsonConvert.DeserializeObject<UpdateFireDistrictPopupStatusRequestDto>(setting.JsonProperties);

                fireDistrictPopup.ShowFireDistrictPopup = updateFireDistrictPopupStatusRequestDto.ShowFireDistrictPopup;

                setting.JsonProperties = JsonConvert.SerializeObject(fireDistrictPopup);
            }
            else
            {

                fireDistrictPopup.ShowFireDistrictPopup = updateFireDistrictPopupStatusRequestDto.ShowFireDistrictPopup;
                setting.JsonProperties = JsonConvert.SerializeObject(fireDistrictPopup);

                setting.SettingName = ConstantVariables.SETTINGS_FIRE_DISTRICT_POPUP;
            }


            var popupStatus = await _settingsRepository.UpdateAutoDismissCallSettings(setting);
            return CommonResultResponseDto<Setting>.Success(new string[] { ActionStatusHelper.Success }, popupStatus, 0);
        }

        public async Task<CommonResultResponseDto<CanListenToOpenPhoneCallsTimeSettingsResponseDto>> GetCanListenToOpenPhoneCallsTimeSettings()
        {

            Setting BRC = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_CAN_LISTEN_TO_OPEN_PHONE_CALLS);
            if (BRC != null && BRC.Id != 0)
            {
                var canListenToOpenPhoneCallsTimeSettingsDto = JsonConvert.DeserializeObject<CanListenToOpenPhoneCallsTimeSettingsResponseDto>(BRC.JsonProperties);
                return CommonResultResponseDto<CanListenToOpenPhoneCallsTimeSettingsResponseDto>.Success(new string[] { ActionStatusHelper.Success }, canListenToOpenPhoneCallsTimeSettingsDto, 0);
            }
            else
            {
                return CommonResultResponseDto<CanListenToOpenPhoneCallsTimeSettingsResponseDto>.Failure(new string[] { ActionStatusHelper.Error }, null);
            }
        }

        public async Task<CommonResultResponseDto<Setting>> UpdateCanListenToOpenPhoneCallsTimeSettings(UpdateCanListenToOpenPhoneCallsTimeSettingsRequestDto updateCanListenToOpenPhoneCallsTimeSettingsRequestDto)
        {

            var setting = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_CAN_LISTEN_TO_OPEN_PHONE_CALLS);

            if (setting != null)
            {
                var canListenToSettings = JsonConvert.DeserializeObject<UpdateCanListenToOpenPhoneCallsTimeSettingsRequestDto>(setting.JsonProperties);

                canListenToSettings.FromTime = updateCanListenToOpenPhoneCallsTimeSettingsRequestDto.FromTime;
                canListenToSettings.ToTime = updateCanListenToOpenPhoneCallsTimeSettingsRequestDto.ToTime;

                setting.JsonProperties = JsonConvert.SerializeObject(canListenToSettings);
            }
            else
            {
                setting = new Setting
                {
                    SettingName = ConstantVariables.SETTINGS_CAN_LISTEN_TO_OPEN_PHONE_CALLS,
                    JsonProperties = JsonConvert.SerializeObject(updateCanListenToOpenPhoneCallsTimeSettingsRequestDto)
                };

            }

            var timeSettings = await _settingsRepository.UpdateAutoDismissCallSettings(setting);
            return CommonResultResponseDto<Setting>.Success(new string[] { ActionStatusHelper.Success }, timeSettings, 0);
        }

        public async Task<CommonResultResponseDto<GetCalculateBusesParkingLocationSettingResponseDto>> GetCalculateBusesParkingLocationSetting()
        {
            Setting BRC = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_CALCULATE_BUSES_PARKING_LOCATION);
            if (BRC != null && BRC.Id != 0)
            {
                var result = JsonConvert.DeserializeObject<GetCalculateBusesParkingLocationSettingResponseDto>(BRC.JsonProperties);
                return CommonResultResponseDto<GetCalculateBusesParkingLocationSettingResponseDto>.Success(new string[] { ActionStatusHelper.Success }, result, 0);
            }
            else
            {
                return CommonResultResponseDto<GetCalculateBusesParkingLocationSettingResponseDto>.Failure(new string[] { ActionStatusHelper.Error }, null);
            }
        }

        public async Task<CommonResultResponseDto<Setting>> UpdateCalculateBusesParkingLocation(UpdateCalculateBusesParkingLocationRequestDto updateCalculateBusesParkingLocationRequestDto)
        {
            Setting setting = new Setting();
            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_CALCULATE_BUSES_PARKING_LOCATION);
            UpdateCalculateBusesParkingLocationRequestDto newRequest = new UpdateCalculateBusesParkingLocationRequestDto();

            if (brcSettings != null && brcSettings.Id != 0)
            {
                setting = brcSettings;
                newRequest = JsonConvert.DeserializeObject<UpdateCalculateBusesParkingLocationRequestDto>(setting.JsonProperties);

                newRequest.IsEnabled = updateCalculateBusesParkingLocationRequestDto.IsEnabled;

                setting.JsonProperties = JsonConvert.SerializeObject(newRequest);
            }
            else
            {

                newRequest.IsEnabled = updateCalculateBusesParkingLocationRequestDto.IsEnabled;
                setting.JsonProperties = JsonConvert.SerializeObject(newRequest);

                setting.SettingName = ConstantVariables.SETTINGS_CALCULATE_BUSES_PARKING_LOCATION;
            }

            var parkingLocation = await _settingsRepository.UpdateAutoDismissCallSettings(setting);
            return CommonResultResponseDto<Setting>.Success(new string[] { ActionStatusHelper.Success }, parkingLocation, 0);
        }

        public async Task<CommonResultResponseDto<HostSettingResponseDto>> GetHostSetting()
        {

            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_HOSTS);

            var setting = JsonConvert.DeserializeObject<HostSettingResponseDto>(brcSettings.JsonProperties);
            return CommonResultResponseDto<HostSettingResponseDto>.Success(new string[] { ActionStatusHelper.Success }, setting, 0);

        }

        public async Task<CommonResultResponseDto<Setting>> UpdateHostSetting(UpdateHostSettingRequestDto updateHostSettingRequestDto)
        {

            Setting setting = new Setting();

            string host1 = string.Empty;
            int port1 = 0;
            string host2 = string.Empty;
            int port2 = 0;
            string finalDestination = string.Empty;

            if (updateHostSettingRequestDto.SwitchHosts == true)
            {
                CommonResultResponseDto<HostSettingResponseDto> brcSetting = await GetHostSetting();
                if (brcSetting.Data != null)
                {
                    host1 = brcSetting.Data.Host2;
                    port1 = brcSetting.Data.Port2;
                    host2 = brcSetting.Data.Host1;
                    port2 = brcSetting.Data.Port1;
                    finalDestination = brcSetting.Data.FinalDestination;
                }
            }
            else
            {
                host1 = updateHostSettingRequestDto.Host1;
                port1 = updateHostSettingRequestDto.Port1;
                host2 = updateHostSettingRequestDto.Host2;
                port2 = updateHostSettingRequestDto.Port2;
                finalDestination = updateHostSettingRequestDto.FinalDestination;
            }

            SipPeerResponseDto sipPeer = new SipPeerResponseDto
            {
                VoiceHosts = new VoiceHostsResponseDto
                {
                    Host = new List<HostResponseDto>
                    {
                        new HostResponseDto { HostName = host1, Port = port1 },
                        new HostResponseDto { HostName = host2, Port = port2 }
                    }
                },

                FinalDestinationUri = $"+1{updateHostSettingRequestDto.FinalDestination}@PSTN",

                PeerName = "KJEMS",
                IsDefaultPeer = true,

                TerminationHosts = new TerminationHostsResponseDto
                {
                    TerminationHost = new List<TerminationHostResponseDto>
                    {
                        new TerminationHostResponseDto { HostName = "104.235.232.194", CustomerTrafficAllowed = "DOMESTIC" },
                        //new TerminationHostResponseDto { HostName = "144.202.10.112", CustomerTrafficAllowed = "DOMESTIC" },
                        new TerminationHostResponseDto { HostName = "144.121.246.202", CustomerTrafficAllowed = "DOMESTIC" },
                    }
                },

                CallingName = new CallingNameResponseDto
                {
                    Display = true,
                    Enforced = false
                },

                Address = new AddressHostResponseDto
                {
                    HouseNumber = 51,
                    StreetName = "FOREST",
                    StreetSuffix = "RD",
                    City = "MONROE",
                    StateCode = "NY",
                    Zip = 10950,
                    Country = "United States",
                    AddressType = "Service"
                },

                PremiseTrunks = 100
            };

            var pbxControlUrlSetting = await _settingsRepository.GetBackUpAndLiveUrl(ConstantVariables.PBX_CONTROL);

            if (pbxControlUrlSetting == null)
            {
                return CommonResultResponseDto<Setting>.Failure(new string[] { "PBX Control settings missing!" }, null);
            }

            string urlToCall = pbxControlUrlSetting.LiveUrl;
            string token = pbxControlUrlSetting.BackUpUrl;

            RestClient client = new RestClient(urlToCall);
            client.Timeout = -1;

            RestRequest request = new RestRequest(Method.PUT);
            request.AddHeader("Content-Type", "application/xml; charset=utf-8");
            request.AddHeader("Authorization", token);

            string xmlContent = SerializeToString(sipPeer);

            request.AddParameter("application/xml", xmlContent, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                HostSettingResponseDto hostJson = new HostSettingResponseDto();

                Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_HOSTS);

                if (brcSettings.Id != 0)
                {
                    setting = brcSettings;
                    hostJson = JsonConvert.DeserializeObject<HostSettingResponseDto>(setting.JsonProperties);

                    hostJson.Host1 = host1;
                    hostJson.Port1 = port1;
                    hostJson.Host2 = host2;
                    hostJson.Port2 = port2;
                    hostJson.FinalDestination = finalDestination;

                    setting.JsonProperties = JsonConvert.SerializeObject(hostJson);
                }
                else
                {

                    hostJson.Host1 = updateHostSettingRequestDto.Host1;
                    hostJson.Port1 = updateHostSettingRequestDto.Port1;
                    hostJson.Host2 = updateHostSettingRequestDto.Host2;
                    hostJson.Port2 = updateHostSettingRequestDto.Port2;
                    hostJson.FinalDestination = updateHostSettingRequestDto.FinalDestination;
                    setting.JsonProperties = JsonConvert.SerializeObject(hostJson);

                    setting.SettingName = ConstantVariables.SETTINGS_HOSTS;
                }
            }
            else
            {

                return CommonResultResponseDto<Setting>.Failure(new string[] { "Host API returned an error, operation failed!" }, null);
            }

            var hostSetting = await _settingsRepository.UpdateAutoDismissCallSettings(setting);
            return CommonResultResponseDto<Setting>.Success(new string[] { ActionStatusHelper.Success }, hostSetting, 0);

        }

        // To Clean XML
        public string SerializeToString<T>(T value)
        {
            var emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(value.GetType());
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;

            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, value, emptyNamespaces);
                return stream.ToString();
            }
        }



        public async Task<CommonResultResponseDto<AutoUseThisAddressResponseDto>> GetAutoUseThisAddressSettings()
        {
            AutoUseThisAddressResponseDto brc = new AutoUseThisAddressResponseDto();

            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_AUTO_USE_THIS);
            if (brcSettings != null)
            {
                var setting = JsonConvert.DeserializeObject<AutoUseThisAddressResponseDto>(brcSettings.JsonProperties);
                return CommonResultResponseDto<AutoUseThisAddressResponseDto>.Success(new string[] { ActionStatusHelper.Success }, setting, 0);
            }

            return CommonResultResponseDto<AutoUseThisAddressResponseDto>.Success(new string[] { ActionStatusHelper.Success }, brc, 0);
        }

        public async Task<CommonResultResponseDto<Setting>> UpdateEnableDisableAutoUseThisSwitch(bool isEnabled)
        {
            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_AUTO_USE_THIS);
            var autoUseThisAddress = new AutoUseThisAddressResponseDto();

            var setting = brcSettings;
            if (setting != null)
            {
                autoUseThisAddress = JsonConvert.DeserializeObject<AutoUseThisAddressResponseDto>(setting.JsonProperties);
            }
            else
            {
                setting = new Setting();
            }

            autoUseThisAddress.IsEnabled = isEnabled;

            setting.JsonProperties = JsonConvert.SerializeObject(autoUseThisAddress);
            setting.SettingName = ConstantVariables.SETTINGS_AUTO_USE_THIS;

            var autoUseThisSwitch = await _settingsRepository.UpdateAutoDismissCallSettings(setting);
            return CommonResultResponseDto<Setting>.Success(new string[] { ActionStatusHelper.Success }, autoUseThisSwitch, 0);
        }

        public async Task<CommonResultResponseDto<AutoCallStatusResponseDto>> GetAutoCallStatusSettings()
        {
            AutoCallStatusResponseDto brc = new AutoCallStatusResponseDto();

            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_AUTO_CALL_STATUS);
            if (brcSettings != null)
            {
                var setting = JsonConvert.DeserializeObject<AutoCallStatusResponseDto>(brcSettings.JsonProperties);
                return CommonResultResponseDto<AutoCallStatusResponseDto>.Success(new string[] { ActionStatusHelper.Success }, setting, 0);
            }

            return CommonResultResponseDto<AutoCallStatusResponseDto>.Success(new string[] { ActionStatusHelper.Success }, brc, 0);
        }

        public async Task<CommonResultResponseDto<Setting>> UpdateEnableDisableAutoCallStatusSwitch(bool isEnabled)
        {
            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_AUTO_CALL_STATUS);
            var autoCallStatus = new AutoCallStatusResponseDto();

            var setting = brcSettings;
            if (setting != null)
            {
                autoCallStatus = JsonConvert.DeserializeObject<AutoCallStatusResponseDto>(setting.JsonProperties);
            }
            else
            {
                setting = new Setting();
            }

            autoCallStatus.IsEnabled = isEnabled;

            setting.JsonProperties = JsonConvert.SerializeObject(autoCallStatus);
            setting.SettingName = ConstantVariables.SETTINGS_AUTO_CALL_STATUS;

            var statusSwitch = await _settingsRepository.UpdateAutoDismissCallSettings(setting);
            return CommonResultResponseDto<Setting>.Success(new string[] { ActionStatusHelper.Success }, statusSwitch, 0);
        }

        public async Task<CommonResultResponseDto<string>> GetDuplicatePreventionSettings()
        {
            string brc = "";

            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_DUPLICATE_PREVENTION_TIMEOUT);

            if (brcSettings != null)
            {
                brc = brcSettings.JsonProperties;
                return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Success }, brc, 0);
            }

            return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Success }, brc, 0); ;
        }

        public async Task<CommonResultResponseDto<Setting>> UpdateDuplicatePreventionTimeoutSettings(UpdateDuplicatePreventionTimeoutSettingsRequestDto updateDuplicatePreventionTimeoutSettingsRequestDto)
        {
            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_DUPLICATE_PREVENTION_TIMEOUT);
            var setting = brcSettings;

            string jsonString = JsonConvert.SerializeObject(updateDuplicatePreventionTimeoutSettingsRequestDto);

            if (setting == null)
            {
                setting = new Setting();
            }

            setting.JsonProperties = jsonString;
            setting.SettingName = ConstantVariables.SETTINGS_DUPLICATE_PREVENTION_TIMEOUT;

            var timeoutSettings = await _settingsRepository.UpdateAutoDismissCallSettings(setting);
            return CommonResultResponseDto<Setting>.Success(new string[] { ActionStatusHelper.Success }, timeoutSettings, 0);
        }

        public async Task<CommonResultResponseDto<string>> GetShowHideMapviewTabSettings()
        {
            string brc = "";

            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_SHOW_MAPVIEW_ON_RIGHT_SECTION);

            if (brcSettings != null)
            {
                brc = brcSettings.JsonProperties;
                return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Success }, brc, 0);
            }

            return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Success }, brc, 0);
        }

        public async Task<CommonResultResponseDto<Setting>> UpdateShowHideMapviewTabSwitch(UpdateShowHideMapviewTabSwitchRequestDto updateShowHideMapviewTabSwitchRequestDto)
        {
            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_SHOW_MAPVIEW_ON_RIGHT_SECTION);
            var setting = brcSettings;

            string jsonString = JsonConvert.SerializeObject(updateShowHideMapviewTabSwitchRequestDto);

            if (setting == null)
            {
                setting = new Setting();
            }

            setting.JsonProperties = jsonString;
            setting.SettingName = ConstantVariables.SETTINGS_SHOW_MAPVIEW_ON_RIGHT_SECTION;

            var timeoutSettings = await _settingsRepository.UpdateAutoDismissCallSettings(setting);
            return CommonResultResponseDto<Setting>.Success(new string[] { ActionStatusHelper.Success }, timeoutSettings, 0);
        }

        public async Task<CommonResultResponseDto<string>> GetShowHideAddressOnMapviewTabSettings()
        {
            string brc = "";

            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_SHOW_ADDRESS_ON_MAPVIEW_TAB);

            if (brcSettings != null)
            {
                brc = brcSettings.JsonProperties;
                return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Success }, brc, 0);
            }

            return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Success }, brc, 0);
        }

        public async Task<CommonResultResponseDto<Setting>> UpdateShowHideAddressOnMapviewTabSwitch(UpdateShowHideAddressOnMapviewTabSwitchRequestDto updateShowHideAddressOnMapviewTabSwitchRequestDto)
        {
            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_SHOW_ADDRESS_ON_MAPVIEW_TAB);
            var setting = brcSettings;

            string jsonString = JsonConvert.SerializeObject(updateShowHideAddressOnMapviewTabSwitchRequestDto);

            if (setting == null)
            {
                setting = new Setting();
            }

            setting.JsonProperties = jsonString;
            setting.SettingName = ConstantVariables.SETTINGS_SHOW_ADDRESS_ON_MAPVIEW_TAB;

            var timeoutSettings = await _settingsRepository.UpdateAutoDismissCallSettings(setting);
            return CommonResultResponseDto<Setting>.Success(new string[] { ActionStatusHelper.Success }, timeoutSettings, 0);
        }

        public async Task<CommonResultResponseDto<GetHighlightActiveClosestBusZoneSettingsResponseDto>> GetHighlightActiveClosestBusZoneSettings()
        {
            GetHighlightActiveClosestBusZoneSettingsResponseDto brc = new GetHighlightActiveClosestBusZoneSettingsResponseDto();

            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_HIGHLIGHT_ACTIVE_CLOSEST_BUS_ZONE);

            if (brcSettings != null)
            {
                var setting = JsonConvert.DeserializeObject<GetHighlightActiveClosestBusZoneSettingsResponseDto>(brcSettings.JsonProperties);
                return CommonResultResponseDto<GetHighlightActiveClosestBusZoneSettingsResponseDto>.Success(new string[] { ActionStatusHelper.Success }, setting, 0);
            }

            return CommonResultResponseDto<GetHighlightActiveClosestBusZoneSettingsResponseDto>.Success(new string[] { ActionStatusHelper.Success }, brc, 0);
        }

        public async Task<CommonResultResponseDto<Setting>> UpdateEnableDisableHighlightActiveClosestBusZoneSettings(bool isEnabled)
        {
            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_HIGHLIGHT_ACTIVE_CLOSEST_BUS_ZONE);
            var higlightAvtiveClosestBusZoneStatus = new GetHighlightActiveClosestBusZoneSettingsResponseDto();

            var setting = brcSettings;
            if (setting != null)
            {
                higlightAvtiveClosestBusZoneStatus = JsonConvert.DeserializeObject<GetHighlightActiveClosestBusZoneSettingsResponseDto>(setting.JsonProperties);
            }
            else
            {
                setting = new Setting();
            }

            higlightAvtiveClosestBusZoneStatus.IsEnabled = isEnabled;

            setting.JsonProperties = JsonConvert.SerializeObject(higlightAvtiveClosestBusZoneStatus);
            setting.SettingName = ConstantVariables.SETTINGS_HIGHLIGHT_ACTIVE_CLOSEST_BUS_ZONE;

            var busZoneSettings = await _settingsRepository.UpdateAutoDismissCallSettings(setting);
            return CommonResultResponseDto<Setting>.Success(new string[] { ActionStatusHelper.Success }, busZoneSettings, 0);
        }

        public async Task<CommonResultResponseDto<string>> GetAutoLogoutSettings()
        {
            string brc = "";

            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_AUTO_LOGOUT_IDLE_USERS_SETTINGS);

            if (brcSettings != null)
            {
                brc = brcSettings.JsonProperties;

                return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Success }, brc, 0);
            }
            else
            {
                return CommonResultResponseDto<string>.Failure(new string[] { "No setting found" }, brc);
            }
        }

        public async Task<CommonResultResponseDto<Setting>> SaveAutoLogoutSettings(SaveAutoLogoutSettingsRequestDto saveAutoLogoutSettingsRequestDto)
        {
             Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_AUTO_LOGOUT_IDLE_USERS_SETTINGS);
            var setting = brcSettings;

            string jsonString = JsonConvert.SerializeObject(saveAutoLogoutSettingsRequestDto);

            if (setting == null)
            {
                setting = new Setting();
            }

            setting.JsonProperties = jsonString;
            setting.SettingName = ConstantVariables.SETTINGS_AUTO_LOGOUT_IDLE_USERS_SETTINGS;

            var busZoneSettings = await _settingsRepository.UpdateAutoDismissCallSettings(setting);
            return CommonResultResponseDto<Setting>.Success(new string[] { ActionStatusHelper.Success }, busZoneSettings, 0);            
        }

        public async Task<CommonResultResponseDto<GetRadioChannelResponseDto>> GetRadioChannel()
        {
            var getRadioChannel = await _settingsRepository.GetRadioChannel();
            return CommonResultResponseDto<GetRadioChannelResponseDto>.Success(new string[] { ActionStatusHelper.Success }, getRadioChannel);
        }

        public async Task<CommonResultResponseDto<string>> UpdateRadioChannel(UpdateRadioChannelRequestDto saveAutoLogoutSettingsRequestDto)
        {
            if(saveAutoLogoutSettingsRequestDto.DefaultRadioId > 0 )
            {
                var getRadioChannel = await _settingsRepository.UpdateRadioChannel(saveAutoLogoutSettingsRequestDto);
                return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Success }, getRadioChannel);
            }
            else
            {
                return CommonResultResponseDto<string>.Failure(new string[] { "RadioChannel can not be empty." }, null);
            }
        }

        public async Task<CommonResultResponseDto<GetAllSettingsResponseDto>> GetAllSettings()
        {
            var allSettings = new GetAllSettingsResponseDto();
            CreativeSettingsResponseDto creativeSettingsResponseDto = new CreativeSettingsResponseDto();
            DispatchAlertResponseDto dispatchAlertResponseDto = new DispatchAlertResponseDto();
            OverwriteAddressPopupResponseDto overwriteAddressPopupResponseDto = new OverwriteAddressPopupResponseDto();
            AllowToTransferCallResponseDto allowToTransferCallResponseDto = new AllowToTransferCallResponseDto();
            List<QuotaEntry> quotaEntry = new List<QuotaEntry>();
            JsonProperties jsonProperties = new JsonProperties();
            CountyCallsResponseDto countyCallsResponseDto = new CountyCallsResponseDto();
            NotificationPopupResponseDto notificationPopupResponseDto = new NotificationPopupResponseDto();
            FireDistrictPopupSettingResponseDto fireDistrictPopupSettingResponseDto = new FireDistrictPopupSettingResponseDto();
            CanListenToOpenPhoneCallsTimeSettingsResponseDto canListenToOpenPhoneCallsTimeSettingsResponseDto = new CanListenToOpenPhoneCallsTimeSettingsResponseDto();
            GetCalculateBusesParkingLocationSettingResponseDto getCalculateBusesParkingLocationSettingResponseDto = new GetCalculateBusesParkingLocationSettingResponseDto();
            AutoUseThisAddressResponseDto autoUseThisAddressResponseDto = new AutoUseThisAddressResponseDto();
            AutoCallStatusResponseDto autoCallStatusResponseDto = new AutoCallStatusResponseDto();
            DuplicatePreventionSettingsResponseDto duplicatePreventionSettingsResponseDto = new DuplicatePreventionSettingsResponseDto();
            ShowHideMapviewTabSettingsResponseDto showHideMapviewTabSettingsResponseDto = new ShowHideMapviewTabSettingsResponseDto();
            ShowHideAddressOnMapviewTabSettingsResponseDto showHideAddressOnMapviewTabSettingsResponseDto = new ShowHideAddressOnMapviewTabSettingsResponseDto();
            GetHighlightActiveClosestBusZoneSettingsResponseDto getHighlightActiveClosestBusZoneSettingsResponseDto = new GetHighlightActiveClosestBusZoneSettingsResponseDto();
            AutoLogoutSettingsResponseDto autoLogoutSettingsResponseDto = new AutoLogoutSettingsResponseDto();

            var BRC = await _settingsRepository.GetAllSettings();
            foreach (var item in BRC)
            {
                if (item.SettingName == ConstantVariables.SETTINGS_CREATIVE_OPTIONS)
                {
                    creativeSettingsResponseDto = JsonConvert.DeserializeObject<CreativeSettingsResponseDto>(item.JsonProperties);
                    allSettings.creativeSettings = creativeSettingsResponseDto;
                }
                else if (item.SettingName == ConstantVariables.SETTINGS_DISPATCH_ALERT)
                {
                    dispatchAlertResponseDto = JsonConvert.DeserializeObject<DispatchAlertResponseDto>(item.JsonProperties);
                    allSettings.dispatchAlert = dispatchAlertResponseDto;
                }
                else if (item.SettingName == ConstantVariables.SETTINGS_OVERWRITE_ADDRESS)
                {
                    overwriteAddressPopupResponseDto = JsonConvert.DeserializeObject<OverwriteAddressPopupResponseDto>(item.JsonProperties);
                    allSettings.overwriteAddressPopup = overwriteAddressPopupResponseDto;
                }
                else if (item.SettingName == ConstantVariables.SETTINGS_ALLOW_TO_TRANSFER_CALL)
                {
                    allowToTransferCallResponseDto = JsonConvert.DeserializeObject<AllowToTransferCallResponseDto>(item.JsonProperties);
                    allSettings.allowToTransferCall = allowToTransferCallResponseDto;
                }
                else if (item.SettingName == ConstantVariables.SETTINGS_SUMMARY_QUOTA_SETTINGS)
                {
                    quotaEntry = JsonConvert.DeserializeObject<List<QuotaEntry>>(item.JsonProperties);
                    allSettings.quotaEntry = quotaEntry;
                }
                else if (item.SettingName == ConstantVariables.SETTINGS_MESSAGE_VALID_UNTIL)
                {
                    jsonProperties = JsonConvert.DeserializeObject<JsonProperties>(item.JsonProperties);
                    allSettings.jsonProperties = jsonProperties;
                }
                else if (item.SettingName == ConstantVariables.SETTINGS_COUNTY_CALLS)
                {
                    countyCallsResponseDto = JsonConvert.DeserializeObject<CountyCallsResponseDto>(item.JsonProperties);
                    allSettings.countyCalls = countyCallsResponseDto;
                }
                else if (item.SettingName == ConstantVariables.SETTINGS_NOTIFICATION_POPUP_HOVER)
                {
                    notificationPopupResponseDto = JsonConvert.DeserializeObject<NotificationPopupResponseDto>(item.JsonProperties);
                    allSettings.notificationPopup = notificationPopupResponseDto;
                }
                else if (item.SettingName == ConstantVariables.SETTINGS_FIRE_DISTRICT_POPUP)
                {
                    fireDistrictPopupSettingResponseDto = JsonConvert.DeserializeObject<FireDistrictPopupSettingResponseDto>(item.JsonProperties);
                    allSettings.fireDistrictPopupSetting = fireDistrictPopupSettingResponseDto;
                }
                else if (item.SettingName == ConstantVariables.SETTINGS_CAN_LISTEN_TO_OPEN_PHONE_CALLS)
                {
                    canListenToOpenPhoneCallsTimeSettingsResponseDto = JsonConvert.DeserializeObject<CanListenToOpenPhoneCallsTimeSettingsResponseDto>(item.JsonProperties);
                    allSettings.canListenToOpenPhoneCallsTimeSettings = canListenToOpenPhoneCallsTimeSettingsResponseDto;
                }
                else if (item.SettingName == ConstantVariables.SETTINGS_CALCULATE_BUSES_PARKING_LOCATION)
                {
                    getCalculateBusesParkingLocationSettingResponseDto = JsonConvert.DeserializeObject<GetCalculateBusesParkingLocationSettingResponseDto>(item.JsonProperties);
                    allSettings.getCalculateBusesParkingLocationSetting = getCalculateBusesParkingLocationSettingResponseDto;
                }
                else if (item.SettingName == ConstantVariables.SETTINGS_AUTO_USE_THIS)
                {
                    autoUseThisAddressResponseDto = JsonConvert.DeserializeObject<AutoUseThisAddressResponseDto>(item.JsonProperties);
                    allSettings.autoUseThisAddress = autoUseThisAddressResponseDto;
                }
                else if (item.SettingName == ConstantVariables.SETTINGS_AUTO_CALL_STATUS)
                {
                    autoCallStatusResponseDto = JsonConvert.DeserializeObject<AutoCallStatusResponseDto>(item.JsonProperties);
                    allSettings.autoCallStatus = autoCallStatusResponseDto;
                }
                else if (item.SettingName == ConstantVariables.SETTINGS_DUPLICATE_PREVENTION_TIMEOUT)
                {
                    duplicatePreventionSettingsResponseDto = JsonConvert.DeserializeObject<DuplicatePreventionSettingsResponseDto>(item.JsonProperties);
                    allSettings.duplicatePreventionSettings = duplicatePreventionSettingsResponseDto;
                }
                else if (item.SettingName == ConstantVariables.SETTINGS_SHOW_MAPVIEW_ON_RIGHT_SECTION)
                {
                    showHideMapviewTabSettingsResponseDto = JsonConvert.DeserializeObject<ShowHideMapviewTabSettingsResponseDto>(item.JsonProperties);
                    allSettings.showHideMapviewTabSettings = showHideMapviewTabSettingsResponseDto;
                }
                else if (item.SettingName == ConstantVariables.SETTINGS_SHOW_ADDRESS_ON_MAPVIEW_TAB)
                {
                    showHideAddressOnMapviewTabSettingsResponseDto = JsonConvert.DeserializeObject<ShowHideAddressOnMapviewTabSettingsResponseDto>(item.JsonProperties);
                    allSettings.showHideAddressOnMapviewTabSettings = showHideAddressOnMapviewTabSettingsResponseDto;
                }
                else if (item.SettingName == ConstantVariables.SETTINGS_HIGHLIGHT_ACTIVE_CLOSEST_BUS_ZONE)
                {
                    getHighlightActiveClosestBusZoneSettingsResponseDto = JsonConvert.DeserializeObject<GetHighlightActiveClosestBusZoneSettingsResponseDto>(item.JsonProperties);
                    allSettings.getHighlightActiveClosestBusZoneSettings = getHighlightActiveClosestBusZoneSettingsResponseDto;
                }
                else if (item.SettingName == ConstantVariables.SETTINGS_AUTO_LOGOUT_IDLE_USERS_SETTINGS)
                {
                    autoLogoutSettingsResponseDto = JsonConvert.DeserializeObject<AutoLogoutSettingsResponseDto>(item.JsonProperties);
                    allSettings.autoLogoutSettings = autoLogoutSettingsResponseDto;
                }
            }
            return CommonResultResponseDto<GetAllSettingsResponseDto>.Success(new string[] {"Success"}, allSettings, 0);
        }
    }
}