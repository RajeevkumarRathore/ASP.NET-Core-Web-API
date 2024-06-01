using Domain.Entities;
using DTO.Request.Report;
using DTO.Request.Settings;
using DTO.Response;
using DTO.Response.Report;
using DTO.Response.Settings;

namespace Application.Abstraction.Services
{
    public interface ISettingsService
    {
        Task<CommonResultResponseDto<CreativeSettingsResponseDto>> GetAllCreativeSettings();
        Task<CommonResultResponseDto<Setting>> UpdateJsonProperty(UpdateJsonPropertyRequestDto updateJsonPropertyRequestDto);
        Task<CommonResultResponseDto<string>> UpdateCreativePbxStatus(UpdateCreativePbxStatusRequestDto updateCreativePbxStatusRequestDto);
        Task<CommonResultResponseDto<string>> UpdateDatavancedPbxStatus(UpdateDatavancedPbxStatusRequestDto updateDatavancedPbxStatusRequestDto);
        Task<CommonResultResponseDto<DispatchAlertResponseDto>> GetDispatchDelay();
        Task<CommonResultResponseDto<Setting>> UpdateDispatchAlertSettings(UpdateDispatchAlertSettingsRequestDto updateDispatchAlertSettingsRequestDto);
        Task<CommonResultResponseDto<Setting>> UpdateAutoDismissCallSettings(UpdateAutoDismissCallSettingsRequestDto updateAutoDismissCallSettingsRequestDto);
        Task<CommonResultResponseDto<Setting>> UpdateEnableDisableAutoDismissCallSwitch(bool isEnabled);
        Task<CommonResultResponseDto<string>> DismissAllActiveCalls();
        Task<CommonResultResponseDto<FontSizeSettingResponseDto>> GetClientInfoPageFontSizeSetting();
        Task<CommonResultResponseDto<Setting>> UpdateClientInfoPageFontSizeSettings(UpdateClientInfoPageFontSizeSettingsRequestDto updateAutoDismissCallSettingsRequestDto);
        Task<CommonResultResponseDto<OverwriteAddressPopupResponseDto>> GetOverwriteAddressPopupSettings();
        Task<CommonResultResponseDto<Setting>> UpdateEnableDisableOverwriteAddressPopupSwitch(bool isEnabled);
        Task<CommonResultResponseDto<AllowToTransferCallResponseDto>> GetAllowToTransferCallSettings();
        Task<CommonResultResponseDto<Setting>> UpdateAllowToTransferCallSwitch(bool isEnabled);
        Task<CommonResultResponseDto<List<QuotaEntry>>> GetSummaryQuotaSettings();
        Task<CommonResultResponseDto<Setting>> SaveSummaryQuotaSettings(SaveSummaryQuotaSettingRequestDto saveSummaryQuotaSettingRequestDto);
        Task<CommonResultResponseDto<JsonProperties>> GetNotificationMessageValidTimeSetting();
        Task<CommonResultResponseDto<Setting>> UpdateNotificationValidTimeSetting(UpdateNotificationValidTimeSettingRequestDto updateNotificationValidTimeSettingRequestDto);
        Task<CommonResultResponseDto<CountyCallsResponseDto>> GetCountyCallsSetting();
        Task<CommonResultResponseDto<Setting>> UpdateCountyCallsStatus(UpdateCountyCallsStatusRequestDto updateCountyCallsStatusRequestDto);
        Task<CommonResultResponseDto<NotificationPopupResponseDto>> GetNotificationPopupSetting();
        Task<CommonResultResponseDto<Setting>> UpdateNotificationPopupStatus(UpdateNotificationPopupStatusRequestDto updateNotificationPopupStatusRequestDto);
        Task<CommonResultResponseDto<FireDistrictPopupSettingResponseDto>> GetFireDistrictPopupSetting();
        Task<CommonResultResponseDto<Setting>> UpdateFireDistrictPopupStatus(UpdateFireDistrictPopupStatusRequestDto updateFireDistrictPopupStatusRequestDto);
        Task<CommonResultResponseDto<CanListenToOpenPhoneCallsTimeSettingsResponseDto>> GetCanListenToOpenPhoneCallsTimeSettings();
        Task<CommonResultResponseDto<Setting>> UpdateCanListenToOpenPhoneCallsTimeSettings(UpdateCanListenToOpenPhoneCallsTimeSettingsRequestDto updateCanListenToOpenPhoneCallsTimeSettingsRequestDto);
        Task<CommonResultResponseDto<GetCalculateBusesParkingLocationSettingResponseDto>> GetCalculateBusesParkingLocationSetting();
        Task<CommonResultResponseDto<Setting>> UpdateCalculateBusesParkingLocation(UpdateCalculateBusesParkingLocationRequestDto updateCalculateBusesParkingLocationRequestDto);
        Task<CommonResultResponseDto<HostSettingResponseDto>> GetHostSetting();
        Task<CommonResultResponseDto<Setting>> UpdateHostSetting(UpdateHostSettingRequestDto updateHostSettingRequestDto);
        Task<CommonResultResponseDto<AutoUseThisAddressResponseDto>> GetAutoUseThisAddressSettings();
        Task<CommonResultResponseDto<Setting>> UpdateEnableDisableAutoUseThisSwitch(bool isEnabled);
        Task<CommonResultResponseDto<AutoCallStatusResponseDto>> GetAutoCallStatusSettings();
        Task<CommonResultResponseDto<Setting>> UpdateEnableDisableAutoCallStatusSwitch(bool isEnabled);
        Task<CommonResultResponseDto<string>> GetDuplicatePreventionSettings();
        Task<CommonResultResponseDto<Setting>> UpdateDuplicatePreventionTimeoutSettings(UpdateDuplicatePreventionTimeoutSettingsRequestDto updateDuplicatePreventionTimeoutSettingsRequestDto);
        Task<CommonResultResponseDto<string>> GetShowHideMapviewTabSettings();
        Task<CommonResultResponseDto<Setting>> UpdateShowHideMapviewTabSwitch(UpdateShowHideMapviewTabSwitchRequestDto updateShowHideMapviewTabSwitchRequestDto);
        Task<CommonResultResponseDto<string>> GetShowHideAddressOnMapviewTabSettings();
        Task<CommonResultResponseDto<Setting>> UpdateShowHideAddressOnMapviewTabSwitch(UpdateShowHideAddressOnMapviewTabSwitchRequestDto updateShowHideAddressOnMapviewTabSwitchRequestDto);
        Task<CommonResultResponseDto<GetHighlightActiveClosestBusZoneSettingsResponseDto>> GetHighlightActiveClosestBusZoneSettings();
        Task<CommonResultResponseDto<Setting>> UpdateEnableDisableHighlightActiveClosestBusZoneSettings(bool isEnabled);
        Task<CommonResultResponseDto<string>> GetAutoLogoutSettings();
        Task<CommonResultResponseDto<Setting>> SaveAutoLogoutSettings(SaveAutoLogoutSettingsRequestDto saveAutoLogoutSettingsRequestDto);
        Task<CommonResultResponseDto<GetRadioChannelResponseDto>> GetRadioChannel();
        Task<CommonResultResponseDto<string>> UpdateRadioChannel(UpdateRadioChannelRequestDto saveAutoLogoutSettingsRequestDto);
        Task<CommonResultResponseDto<GetAllSettingsResponseDto>> GetAllSettings();

    }
}
