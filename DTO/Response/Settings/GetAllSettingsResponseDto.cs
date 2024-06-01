using DTO.Request.Report;
using DTO.Response.Report;

namespace DTO.Response.Settings
{
    public class GetAllSettingsResponseDto
    {
        public GetAllSettingsResponseDto()
        {
            creativeSettings = new CreativeSettingsResponseDto();
            dispatchAlert = new DispatchAlertResponseDto();
            overwriteAddressPopup = new OverwriteAddressPopupResponseDto();
            allowToTransferCall = new AllowToTransferCallResponseDto();
            quotaEntry = new List<QuotaEntry>();
            jsonProperties = new JsonProperties();
            countyCalls = new CountyCallsResponseDto();
            notificationPopup = new NotificationPopupResponseDto();
            fireDistrictPopupSetting = new FireDistrictPopupSettingResponseDto();
            canListenToOpenPhoneCallsTimeSettings = new CanListenToOpenPhoneCallsTimeSettingsResponseDto();
            getCalculateBusesParkingLocationSetting = new GetCalculateBusesParkingLocationSettingResponseDto();
            autoUseThisAddress = new AutoUseThisAddressResponseDto();
            autoCallStatus = new AutoCallStatusResponseDto();
            duplicatePreventionSettings = new DuplicatePreventionSettingsResponseDto();
            showHideMapviewTabSettings = new ShowHideMapviewTabSettingsResponseDto();
            showHideAddressOnMapviewTabSettings = new ShowHideAddressOnMapviewTabSettingsResponseDto();
            getHighlightActiveClosestBusZoneSettings = new GetHighlightActiveClosestBusZoneSettingsResponseDto();
            autoLogoutSettings = new AutoLogoutSettingsResponseDto();
        }
        public CreativeSettingsResponseDto creativeSettings { get; set; }
        public DispatchAlertResponseDto dispatchAlert { get; set; }
        public OverwriteAddressPopupResponseDto overwriteAddressPopup { get; set; }
        public AllowToTransferCallResponseDto allowToTransferCall { get; set; }
        public List<QuotaEntry> quotaEntry { get; set; }
        public JsonProperties jsonProperties { get; set; }
        public CountyCallsResponseDto countyCalls { get; set; }
        public NotificationPopupResponseDto notificationPopup { get; set; }
        public FireDistrictPopupSettingResponseDto fireDistrictPopupSetting { get; set; }
        public CanListenToOpenPhoneCallsTimeSettingsResponseDto canListenToOpenPhoneCallsTimeSettings { get; set; }
        public GetCalculateBusesParkingLocationSettingResponseDto getCalculateBusesParkingLocationSetting { get; set; }
        public AutoUseThisAddressResponseDto autoUseThisAddress { get; set; }
        public AutoCallStatusResponseDto  autoCallStatus { get; set; }
        public DuplicatePreventionSettingsResponseDto duplicatePreventionSettings { get; set; }
        public ShowHideMapviewTabSettingsResponseDto showHideMapviewTabSettings { get; set; }
        public ShowHideAddressOnMapviewTabSettingsResponseDto showHideAddressOnMapviewTabSettings { get; set; }
        public GetHighlightActiveClosestBusZoneSettingsResponseDto getHighlightActiveClosestBusZoneSettings { get; set; }
        public AutoLogoutSettingsResponseDto autoLogoutSettings { get; set; }

    }
}
