using Application.Handler.Member.Command.UpdateCallTextOnOffStatus;
using Application.Handler.Member.Command.UpdateGeneralNotificationsOnOffStatus;
using Application.Handler.Member.Queries.GetCallTextOnOffStatus;
using Application.Handler.Member.Queries.GetNotificationsOnOffStatus;
using Application.Handler.Settings.Command.SaveAutoLogoutSettings;
using Application.Handler.Settings.Command.SaveSummaryQuotaSettings;
using Application.Handler.Settings.Command.UpdateAllowToTransferCallSwitch;
using Application.Handler.Settings.Command.UpdateAutoDismissCallSettings;
using Application.Handler.Settings.Command.UpdateCalculateBusesParkingLocation;
using Application.Handler.Settings.Command.UpdateCanListenToOpenPhoneCallsTimeSettings;
using Application.Handler.Settings.Command.UpdateClientInfoPageFontSizeSettings;
using Application.Handler.Settings.Command.UpdateCountyCallsStatus;
using Application.Handler.Settings.Command.UpdateCreativePbxStatus;
using Application.Handler.Settings.Command.UpdateDatavancedPbxStatus;
using Application.Handler.Settings.Command.UpdateDispatchAlertSettings;
using Application.Handler.Settings.Command.UpdateDuplicatePreventionTimeoutSettings;
using Application.Handler.Settings.Command.UpdateEnableDisableAutoCallStatusSwitch;
using Application.Handler.Settings.Command.UpdateEnableDisableAutoDismissCallSwitch;
using Application.Handler.Settings.Command.UpdateEnableDisableAutoUseThisSwitch;
using Application.Handler.Settings.Command.UpdateEnableDisableHighlightActiveClosestBusZoneSettings;
using Application.Handler.Settings.Command.UpdateEnableDisableOverwriteAddressPopupSwitch;
using Application.Handler.Settings.Command.UpdateFireDistrictPopupStatus;
using Application.Handler.Settings.Command.UpdateHostSetting;
using Application.Handler.Settings.Command.UpdateJsonProperty;
using Application.Handler.Settings.Command.UpdateNotificationPopupStatus;
using Application.Handler.Settings.Command.UpdateNotificationValidTimeSetting;
using Application.Handler.Settings.Command.UpdateRadioChannel;
using Application.Handler.Settings.Command.UpdateShowHideAddressOnMapviewTabSwitch;
using Application.Handler.Settings.Command.UpdateShowHideMapviewTabSwitch;
using Application.Handler.Settings.Queries.DismissAllActiveCalls;
using Application.Handler.Settings.Queries.GetAllCreativeSettings;
using Application.Handler.Settings.Queries.GetAllowToTransferCallSettings;
using Application.Handler.Settings.Queries.GetAllSettings;
using Application.Handler.Settings.Queries.GetAutoCallStatusSettings;
using Application.Handler.Settings.Queries.GetAutoLogoutSettings;
using Application.Handler.Settings.Queries.GetAutoUseThisAddressSettings;
using Application.Handler.Settings.Queries.GetCalculateBusesParkingLocationSetting;
using Application.Handler.Settings.Queries.GetCanListenToOpenPhoneCallsTimeSettings;
using Application.Handler.Settings.Queries.GetClientInfoPageFontSizeSetting;
using Application.Handler.Settings.Queries.GetCountyCallsSetting;
using Application.Handler.Settings.Queries.GetDispatchDelay;
using Application.Handler.Settings.Queries.GetDuplicatePreventionSettings;
using Application.Handler.Settings.Queries.GetFireDistrictPopupSetting;
using Application.Handler.Settings.Queries.GetHighlightActiveClosestBusZoneSettings;
using Application.Handler.Settings.Queries.GetHostSetting;
using Application.Handler.Settings.Queries.GetNotificationMessageValidTimeSetting;
using Application.Handler.Settings.Queries.GetNotificationPopupSetting;
using Application.Handler.Settings.Queries.GetOverwriteAddressPopupSettings;
using Application.Handler.Settings.Queries.GetRadioChannel;
using Application.Handler.Settings.Queries.GetShowHideAddressOnMapviewTabSettings;
using Application.Handler.Settings.Queries.GetShowHideMapviewTabSettings;
using Application.Handler.Settings.Queries.GetSummaryQuotaSettings;
using Application.Handler.ShiftSchedule.Queries.GetAutoDismissCallSettings;
using DTO.Request.Member;
using DTO.Request.Settings;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    public class SettingsController : BaseController
    {
        #region Creative Settings

        #region Command

        [HttpPost]
        [Route("UpdateJsonProperty")]
        public async Task<IActionResult> UpdateJsonProperty([FromBody] UpdateJsonPropertyRequestDto updateJsonPropertyRequestDto)
        {
            var result = await Mediator.Send(updateJsonPropertyRequestDto.Adapt<UpdateJsonPropertyCommand>());
            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateCreativePbxStatus")]
        public async Task<IActionResult> UpdateCreativePbxStatus([FromBody] UpdateCreativePbxStatusRequestDto updateCreativePbxStatusRequestDto)
        {
            var result = await Mediator.Send(updateCreativePbxStatusRequestDto.Adapt<UpdateCreativePbxStatusCommand>());
            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateDatavancedPbxStatus")]
        public async Task<IActionResult> UpdateDatavancedPbxStatus([FromBody] UpdateDatavancedPbxStatusRequestDto updateDatavancedPbxStatusRequestDto)
        {
            var result = await Mediator.Send(updateDatavancedPbxStatusRequestDto.Adapt<UpdateDatavancedPbxStatusCommand>());
            return Ok(result);
        }

        #endregion

        #region Queries

        [HttpGet]
        [Route("GetAllCreativeSettings")]
        public async Task<IActionResult> GetAllCreativeSettings()
        {
            var result = await Mediator.Send(new GetAllCreativeSettingsQuery());
            return Ok(result);
        }

        #endregion

        #endregion

        #region Dispatch Alert

        #region Command

        [HttpPost]
        [Route("UpdateDispatchAlertSettings")]
        public async Task<IActionResult> UpdateDispatchAlertSettings([FromBody] UpdateDispatchAlertSettingsRequestDto updateDispatchAlertSettingsRequestDto)
        {
            var result = await Mediator.Send(updateDispatchAlertSettingsRequestDto.Adapt<UpdateDispatchAlertSettingsCommand>());
            return Ok(result);
        }

        #endregion

        #region Queries

        [HttpGet]
        [Route("GetDispatchDelay")]
        public async Task<IActionResult> GetDispatchDelay()
        {
            var result = await Mediator.Send(new GetDispatchDelayQuery());
            return Ok(result);
        }

        #endregion

        #endregion

        #region Auto Dismiss Call

        #region Command

        [HttpPost]
        [Route("UpdateAutoDismissCallSettings")]
        public async Task<IActionResult> UpdateAutoDismissCallSettings([FromBody] UpdateAutoDismissCallSettingsRequestDto updateAutoDismissCallSettingsRequestDto)
        {
            var result = await Mediator.Send(updateAutoDismissCallSettingsRequestDto.Adapt<UpdateAutoDismissCallSettingsCommand>());
            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateEnableDisableAutoDismissCallSwitch")]
        public async Task<IActionResult> UpdateEnableDisableAutoDismissCallSwitch([FromQuery] bool isEnabled)
        {
            var result = await Mediator.Send(new UpdateEnableDisableAutoDismissCallSwitchCommand { IsEnabled = isEnabled });
            return Ok(result);
        }

        #endregion

        #region Queries

        [HttpGet]
        [Route("GetAutoDismissCallSettings")]
        public async Task<IActionResult> GetAutoDismissCallSettings()
        {
            var result = await Mediator.Send(new GetAutoDismissCallSettingsQuery());
            return Ok(result);
        }

        [HttpGet]
        [Route("DismissAllActiveCalls")]
        public async Task<IActionResult> DismissAllActiveCalls()
        {
            var result = await Mediator.Send(new DismissAllActiveCallsQuery());
            return Ok(result);
        }

        #endregion

        #endregion

        #region Homepage Font Settings

        #region Command

        [HttpPost]
        [Route("UpdateClientInfoPageFontSizeSettings")]
        public async Task<IActionResult> UpdateClientInfoPageFontSizeSettings([FromBody] UpdateClientInfoPageFontSizeSettingsRequestDto updateAutoDismissCallSettingsRequestDto)
        {
            var result = await Mediator.Send(updateAutoDismissCallSettingsRequestDto.Adapt<UpdateClientInfoPageFontSizeSettingsCommand>());
            return Ok(result);
        }

        #endregion

        #region Queries

        [HttpGet]
        [Route("GetClientInfoPageFontSizeSetting")]
        public async Task<IActionResult> GetClientInfoPageFontSizeSetting()
        {
            var result = await Mediator.Send(new GetClientInfoPageFontSizeSettingQuery());
            return Ok(result);
        }

        #endregion

        #endregion

        #region Overwrite Address Popup

        #region Command

        [HttpPost]
        [Route("UpdateEnableDisableOverwriteAddressPopupSwitch")]
        public async Task<IActionResult> UpdateEnableDisableOverwriteAddressPopupSwitch([FromQuery] bool isEnabled)
        {
            var result = await Mediator.Send(new UpdateEnableDisableOverwriteAddressPopupSwitchCommand { IsEnabled = isEnabled });
            return Ok(result);
        }

        #endregion

        #region Queries

        [HttpGet]
        [Route("GetOverwriteAddressPopupSettings")]
        public async Task<IActionResult> GetOverwriteAddressPopupSettings()
        {
            var result = await Mediator.Send(new GetOverwriteAddressPopupSettingsQuery());
            return Ok(result);
        }

        #endregion

        #endregion

        #region Allow To Transfer Call

        #region Command

        [HttpPost]
        [Route("UpdateAllowToTransferCallSwitch")]
        public async Task<IActionResult> UpdateAllowToTransferCallSwitch([FromQuery] bool isEnabled)
        {
            var result = await Mediator.Send(new UpdateAllowToTransferCallSwitchCommand { IsEnabled = isEnabled });
            return Ok(result);
        }

        #endregion

        #region Queries

        [HttpGet]
        [Route("GetAllowToTransferCallSettings")]
        public async Task<IActionResult> GetAllowToTransferCallSettings()
        {
            var result = await Mediator.Send(new GetAllowToTransferCallSettingsQuery());
            return Ok(result);
        }

        #endregion

        #endregion

        #region Summary Settings

        #region Command

        [HttpPost]
        [Route("SaveSummaryQuotaSettings")]
        public async Task<IActionResult> SaveSummaryQuotaSettings([FromBody] SaveSummaryQuotaSettingRequestDto saveSummaryQuotaSettingRequestDto)
        {
            var result = await Mediator.Send(saveSummaryQuotaSettingRequestDto.Adapt<SaveSummaryQuotaSettingsCommand>());
            return Ok(result);
        }

        #endregion

        #region Queries

        [HttpGet]
        [Route("GetSummaryQuotaSettings")]
        public async Task<IActionResult> GetSummaryQuotaSettings()
        {
            var result = await Mediator.Send(new GetSummaryQuotaSettingsQuery());
            return Ok(result);
        }

        #endregion

        #endregion

        #region Call Text On/Off

        #region Command

        [HttpPost]
        [Route("UpdateCallTextOnOffStatus")]
        public async Task<IActionResult> UpdateCallTextOnOffStatus([FromQuery] bool isCallTextOn)
        {
            var result = await Mediator.Send(new UpdateCallTextOnOffStatusCommand { isCallTextOn = isCallTextOn });
            return Ok(result);
        }

        #endregion

        #region Queries
        [HttpGet]
        [Route("GetCallTextOnOffStatus")]
        public async Task<IActionResult> GetCallTextOnOffStatus()
        {
            var result = await Mediator.Send(new GetCallTextOnOffStatusQuery());
            return Ok(result);
        }
        
        #endregion

        #endregion

        #region Notifications On/Off

        #region Command

        [HttpPost]
        [Route("UpdateGeneralNotificationsOnOffStatus")]
        public async Task<IActionResult> UpdateGeneralNotificationsOnOffStatus([FromBody] GetNotificationsOnOffStatusRequest getNotificationsOnOffStatusRequest)
        {
            var result = await Mediator.Send(getNotificationsOnOffStatusRequest.Adapt<UpdateGeneralNotificationsOnOffStatusCommand>());
            return Ok(result);
        }

        #endregion

        #region Queries
        [HttpGet]
        [Route("GetNotificationsOnOffStatus")]
        public async Task<IActionResult> GetNotificationsOnOffStatus()
        {
            var result = await Mediator.Send(new GetNotificationsOnOffStatusQuery());
            return Ok(result);
        }
        #endregion

        #endregion

        #region Notification Message Validity Time

        #region Command

        [HttpPost]
        [Route("UpdateNotificationValidTimeSetting")]
        public async Task<IActionResult> UpdateNotificationValidTimeSetting([FromBody] UpdateNotificationValidTimeSettingRequestDto updateNotificationValidTimeSettingRequestDto)
        {
            var result = await Mediator.Send(updateNotificationValidTimeSettingRequestDto.Adapt<UpdateNotificationValidTimeSettingCommand>());
            return Ok(result);
        }

        #endregion

        #region Queries
        [HttpGet]
        [Route("GetNotificationMessageValidTimeSetting")]
        public async Task<IActionResult> GetNotificationMessageValidTimeSetting()
        {
            var result = await Mediator.Send(new GetNotificationMessageValidTimeSettingQuery());
            return Ok(result);
        }
        #endregion

        #endregion

        #region County Calls

        #region Command

        [HttpPost]
        [Route("UpdateCountyCallsStatus")]
        public async Task<IActionResult> UpdateCountyCallsStatus([FromBody] UpdateCountyCallsStatusRequestDto updateCountyCallsStatusRequestDto)
        {
            var result = await Mediator.Send(updateCountyCallsStatusRequestDto.Adapt<UpdateCountyCallsStatusCommand>());
            return Ok(result);
        }

        #endregion

        #region Queries
        [HttpGet]
        [Route("GetCountyCallsSetting")]
        public async Task<IActionResult> GetCountyCallsSetting()
        {
            var result = await Mediator.Send(new GetCountyCallsSettingQuery());
            return Ok(result);
        }
        #endregion

        #endregion

        #region Notification Popup

        #region Command

        [HttpPost]
        [Route("UpdateNotificationPopupStatus")]
        public async Task<IActionResult> UpdateNotificationPopupStatus([FromBody] UpdateNotificationPopupStatusRequestDto updateNotificationPopupStatusRequestDto)
        {
            var result = await Mediator.Send(updateNotificationPopupStatusRequestDto.Adapt<UpdateNotificationPopupStatusCommand>());
            return Ok(result);
        }

        #endregion

        #region Queries
        [HttpGet]
        [Route("GetNotificationPopupSetting")]
        public async Task<IActionResult> GetNotificationPopupSetting()
        {
            var result = await Mediator.Send(new GetNotificationPopupSettingQuery());
            return Ok(result);
        }
        #endregion

        #endregion

        #region Fire District Popup

        #region Command

        [HttpPost]
        [Route("UpdateFireDistrictPopupStatus")]
        public async Task<IActionResult> UpdateFireDistrictPopupStatus([FromBody] UpdateFireDistrictPopupStatusRequestDto updateFireDistrictPopupStatusRequestDto)
        {
            var result = await Mediator.Send(updateFireDistrictPopupStatusRequestDto.Adapt<UpdateFireDistrictPopupStatusCommand>());
            return Ok(result);
        }

        #endregion

        #region Queries
        [HttpGet]
        [Route("GetFireDistrictPopupSetting")]
        public async Task<IActionResult> GetFireDistrictPopupSetting()
        {
            var result = await Mediator.Send(new GetFireDistrictPopupSettingQuery());
            return Ok(result);
        }
        #endregion

        #endregion

        #region Can Listen To Open Calls

        #region Command

        [HttpPost]
        [Route("UpdateCanListenToOpenPhoneCallsTimeSettings")]
        public async Task<IActionResult> UpdateCanListenToOpenPhoneCallsTimeSettings([FromBody] UpdateCanListenToOpenPhoneCallsTimeSettingsRequestDto updateCanListenToOpenPhoneCallsTimeSettingsRequestDto)
        {
            var result = await Mediator.Send(updateCanListenToOpenPhoneCallsTimeSettingsRequestDto.Adapt<UpdateCanListenToOpenPhoneCallsTimeSettingsCommand>());
            return Ok(result);
        }

        #endregion

        #region Queries
        [HttpGet]
        [Route("GetCanListenToOpenPhoneCallsTimeSettings")]
        public async Task<IActionResult> GetCanListenToOpenPhoneCallsTimeSettings()
        {
            var result = await Mediator.Send(new GetCanListenToOpenPhoneCallsTimeSettingsQuery());
            return Ok(result);
        }
        #endregion

        #endregion

        #region Calculate Buses Parking Location

        #region Command

        [HttpPost]
        [Route("UpdateCalculateBusesParkingLocation")]
        public async Task<IActionResult> UpdateCalculateBusesParkingLocation([FromBody] UpdateCalculateBusesParkingLocationRequestDto updateCalculateBusesParkingLocationRequestDto)
        {
            var result = await Mediator.Send(updateCalculateBusesParkingLocationRequestDto.Adapt<UpdateCalculateBusesParkingLocationCommand>());
            return Ok(result);
        }

        #endregion

        #region Queries
        [HttpGet]
        [Route("GetCalculateBusesParkingLocationSetting")]
        public async Task<IActionResult> GetCalculateBusesParkingLocationSetting()
        {
            var result = await Mediator.Send(new GetCalculateBusesParkingLocationSettingQuery());
            return Ok(result);
        }
        #endregion

        #endregion

        #region PBX Controls

        #region Command

        [HttpPost]
        [Route("UpdateHostSetting")]
        public async Task<IActionResult> UpdateHostSetting([FromBody] UpdateHostSettingRequestDto updateHostSettingRequestDto)
        {
            var result = await Mediator.Send(updateHostSettingRequestDto.Adapt<UpdateHostSettingCommand>());
            return Ok(result);
        }

        #endregion

        #region Queries
        [HttpGet]
        [Route("GetHostSetting")]
        public async Task<IActionResult> GetHostSetting()
        {
            var result = await Mediator.Send(new GetHostSettingQuery());
            return Ok(result);
        }
        #endregion

        #endregion

        #region Auto Use This

        #region Command

        [HttpPost]
        [Route("UpdateEnableDisableAutoUseThisSwitch")]
        public async Task<IActionResult> UpdateEnableDisableAutoUseThisSwitch([FromQuery] bool isEnabled)
        {
            var result = await Mediator.Send(new UpdateEnableDisableAutoUseThisSwitchCommand { IsEnabled = isEnabled });
            return Ok(result);
        }

        #endregion

        #region Queries
        [HttpGet]
        [Route("GetAutoUseThisAddressSettings")]
        public async Task<IActionResult> GetAutoUseThisAddressSettings()
        {
            var result = await Mediator.Send(new GetAutoUseThisAddressSettingsQuery());
            return Ok(result);
        }
        #endregion

        #endregion

        #region Auto Call Status Should Overwrite Manual Call Status

        #region Command

        [HttpPost]
        [Route("UpdateEnableDisableAutoCallStatusSwitch")]
        public async Task<IActionResult> UpdateEnableDisableAutoCallStatusSwitch([FromQuery] bool isEnabled)
        {
            var result = await Mediator.Send(new UpdateEnableDisableAutoCallStatusSwitchCommand { IsEnabled = isEnabled });
            return Ok(result);
        }

        #endregion

        #region Queries
        [HttpGet]
        [Route("GetAutoCallStatusSettings")]
        public async Task<IActionResult> GetAutoCallStatusSettings()
        {
            var result = await Mediator.Send(new GetAutoCallStatusSettingsQuery());
            return Ok(result);
        }
        #endregion

        #endregion

        #region Duplicate Prevention Timeout

        #region Command

        [HttpPost]
        [Route("UpdateDuplicatePreventionTimeoutSettings")]
        public async Task<IActionResult> UpdateDuplicatePreventionTimeoutSettings([FromBody] UpdateDuplicatePreventionTimeoutSettingsRequestDto updateDuplicatePreventionTimeoutSettingsRequestDto )
        {
            var result = await Mediator.Send(updateDuplicatePreventionTimeoutSettingsRequestDto.Adapt<UpdateDuplicatePreventionTimeoutSettingsCommand>());
            return Ok(result);
        }

        #endregion

        #region Queries
        [HttpGet]
        [Route("GetDuplicatePreventionSettings")]
        public async Task<IActionResult> GetDuplicatePreventionSettings()
        {
            var result = await Mediator.Send(new GetDuplicatePreventionSettingsQuery());
            return Ok(result);
        }
        #endregion

        #endregion

        #region Show/Hide Mapview Tab

        #region Command

        [HttpPost]
        [Route("UpdateShowHideMapviewTabSwitch")]
        public async Task<IActionResult> UpdateShowHideMapviewTabSwitch([FromBody] UpdateShowHideMapviewTabSwitchRequestDto updateShowHideMapviewTabSwitchRequestDto)
        {
            var result = await Mediator.Send(updateShowHideMapviewTabSwitchRequestDto.Adapt<UpdateShowHideMapviewTabSwitchCommand>());
            return Ok(result);
        }

        #endregion

        #region Queries
        [HttpGet]
        [Route("GetShowHideMapviewTabSettings")]
        public async Task<IActionResult> GetShowHideMapviewTabSettings()
        {
            var result = await Mediator.Send(new GetShowHideMapviewTabSettingsQuery());
            return Ok(result);
        }
        #endregion

        #endregion

        #region Show/Hide Address On Mapview Tab

        #region Command

        [HttpPost]
        [Route("UpdateShowHideAddressOnMapviewTabSwitch")]
        public async Task<IActionResult> UpdateShowHideAddressOnMapviewTabSwitch([FromBody] UpdateShowHideAddressOnMapviewTabSwitchRequestDto updateShowHideAddressOnMapviewTabSwitchRequestDto)
        {
            var result = await Mediator.Send(updateShowHideAddressOnMapviewTabSwitchRequestDto.Adapt<UpdateShowHideAddressOnMapviewTabSwitchCommand>());
            return Ok(result);
        }

        #endregion

        #region Queries
        [HttpGet]
        [Route("GetShowHideAddressOnMapviewTabSettings")]
        public async Task<IActionResult> GetShowHideAddressOnMapviewTabSettings()
        {
            var result = await Mediator.Send(new GetShowHideAddressOnMapviewTabSettingsQuery());
            return Ok(result);
        }
        #endregion

        #endregion

        #region Highlight Active Closest Bus Zone

        #region Command

        [HttpPost]
        [Route("UpdateEnableDisableHighlightActiveClosestBusZoneSettings")]
        public async Task<IActionResult> UpdateEnableDisableHighlightActiveClosestBusZoneSettings([FromQuery] bool isEnabled)
        {
            var result = await Mediator.Send(new UpdateEnableDisableHighlightActiveClosestBusZoneSettingsCommand { IsEnabled = isEnabled });
            return Ok(result);
        }

        #endregion

        #region Queries
        [HttpGet]
        [Route("GetHighlightActiveClosestBusZoneSettings")]
        public async Task<IActionResult> GetHighlightActiveClosestBusZoneSettings()
        {
            var result = await Mediator.Send(new GetHighlightActiveClosestBusZoneSettingsQuery());
            return Ok(result);
        }
        #endregion

        #endregion

        #region Auto Logout Idle Users Settings

        #region Command

        [HttpPost]
        [Route("SaveAutoLogoutSettings")]
        public async Task<IActionResult> SaveAutoLogoutSettings([FromBody] SaveAutoLogoutSettingsRequestDto saveAutoLogoutSettingsRequestDto)
        {
            var result = await Mediator.Send(saveAutoLogoutSettingsRequestDto.Adapt<SaveAutoLogoutSettingsCommand>());
            return Ok(result);
        }

        #endregion

        #region Queries
        [HttpGet]
        [Route("GetAutoLogoutSettings")]
        public async Task<IActionResult> GetAutoLogoutSettings()
        {
            var result = await Mediator.Send(new GetAutoLogoutSettingsQuery());
            return Ok(result);
        }
        #endregion

        #endregion

        #region Key For Channel

        #region Command

        [HttpPost]
        [Route("UpdateRadioChannel")]
        public async Task<IActionResult> UpdateRadioChannel([FromBody] UpdateRadioChannelRequestDto saveAutoLogoutSettingsRequestDto)
        {
            var result = await Mediator.Send(saveAutoLogoutSettingsRequestDto.Adapt<UpdateRadioChannelCommand>());
            return Ok(result);
        }

        #endregion

        #region Queries
        [HttpGet]
        [Route("GetRadioChannel")]
        public async Task<IActionResult> GetRadioChannel()
        {
            var result = await Mediator.Send(new GetRadioChannelQuery());
            return Ok(result);
        }
        #endregion

        #endregion

        #region Settings
        [HttpGet]
        [Route("GetAllSettings")]
        public async Task<IActionResult> GetAllSettings()
        {
            var result = await Mediator.Send(new GetAllSettingsQuery());
            return Ok(result);
        }
        #endregion
    }
}
