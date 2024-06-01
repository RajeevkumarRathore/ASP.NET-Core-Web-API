using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Application.Common.Helpers;
using Dapper;
using Domain.Entities;
using DTO.Request.Settings;
using DTO.Response.Settings;
using System.Data;

namespace Infrastructure.Implementation.Repositories
{
    public class SettingsRepository : ISettingsRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;
        public SettingsRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;
        }

        public async Task<Setting> UpdateJsonProperty(int id, string jsonProperties)
        {
            return await _dbContext.ExecuteStoredProcedure<Setting>("usp_hatzalah_UpdateJsonProperty",
           _parameterManager.Get("@SettingsId",id ),
           _parameterManager.Get("@JsonProperties",jsonProperties)
           );
        }

        public async Task<DispatchUrlSettingResponseDto> GetBackUpAndLiveUrl(string purpose)
        {
            return await _dbContext.ExecuteStoredProcedure<DispatchUrlSettingResponseDto>("usp_hatzalah_GetBackUpAndLiveUrl",
          _parameterManager.Get("@Purpose", purpose));
        }

        public async Task<Setting> UpdateAutoDismissCallSettings(Setting setting)
        {
            return await _dbContext.ExecuteStoredProcedure<Setting>("usp_hatzalah_UpdateAutoDismissCallSettings",
          _parameterManager.Get("@Id", setting.Id),
          _parameterManager.Get("@SettingName", setting.SettingName),
          _parameterManager.Get("@JsonProperties", setting.JsonProperties)
          );
        }

        public async Task<string> DismissAllActiveCalls()
        {
            return await _dbContext.ExecuteStoredProcedure<string>("usp_hatzalah_DismissAllActiveCalls");
        }

        public async Task<Setting> UpdateClientInfoPageFontSizeSettings(Setting setting)
        {
            return await _dbContext.ExecuteStoredProcedure<Setting>("usp_hatzalah_UpdateClientInfoPageFontSizeSettings",
          _parameterManager.Get("@Id", setting.Id),
          _parameterManager.Get("@SettingName", setting.SettingName),
          _parameterManager.Get("@JsonProperties", setting.JsonProperties)
          );
        }

        public async Task<GetRadioChannelResponseDto> GetRadioChannel()
        {
            return await _dbContext.ExecuteStoredProcedure<GetRadioChannelResponseDto>("usp_hatzalah_GetRadioChannel");
        }

        public async Task<string> UpdateRadioChannel(UpdateRadioChannelRequestDto saveAutoLogoutSettingsRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<string>("usp_hatzalah_UpdateRadioChannel",
          _parameterManager.Get("@RadioChannelId", saveAutoLogoutSettingsRequestDto.RadioChannelId),
          _parameterManager.Get("@DefaultRadioId", saveAutoLogoutSettingsRequestDto.DefaultRadioId),
          _parameterManager.Get("@NightDefaultRadioId", saveAutoLogoutSettingsRequestDto.NightDefaultRadioId),
          _parameterManager.Get("@StartTime", saveAutoLogoutSettingsRequestDto.StartTime),
          _parameterManager.Get("@EndTime", saveAutoLogoutSettingsRequestDto.EndTime)
          );
        }
        public async Task<List<GetSettingsResponseDto>> GetAllSettings()
        {
            List<GetSettingsResponseDto> getSettings;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync("usp_hatzalah_GetAllSettings", _dbContext.GetDapperDynamicParameters(
                  _parameterManager.Get("CreativeSetting", ConstantVariables.SETTINGS_CREATIVE_OPTIONS),
                  _parameterManager.Get("DispatchSetting", ConstantVariables.SETTINGS_DISPATCH_ALERT),
                  _parameterManager.Get("OverwriteAddressSetting", ConstantVariables.SETTINGS_OVERWRITE_ADDRESS),
                  _parameterManager.Get("AllowToTransferCallSetting", ConstantVariables.SETTINGS_ALLOW_TO_TRANSFER_CALL),
                  _parameterManager.Get("SummaryQuotaSetting", ConstantVariables.SETTINGS_SUMMARY_QUOTA_SETTINGS),
                  _parameterManager.Get("MessageValidUntilSetting", ConstantVariables.SETTINGS_MESSAGE_VALID_UNTIL),
                  _parameterManager.Get("CountyCallsSetting", ConstantVariables.SETTINGS_COUNTY_CALLS),
                  _parameterManager.Get("EnableNotificationPopupHoverSetting", ConstantVariables.SETTINGS_NOTIFICATION_POPUP_HOVER),
                  _parameterManager.Get("FireDistrictPopupSetting", ConstantVariables.SETTINGS_FIRE_DISTRICT_POPUP),
                  _parameterManager.Get("CanListenToOpenPhoneCallsSetting", ConstantVariables.SETTINGS_CAN_LISTEN_TO_OPEN_PHONE_CALLS),
                  _parameterManager.Get("CalculateBusesParkingLocationSetting", ConstantVariables.SETTINGS_CALCULATE_BUSES_PARKING_LOCATION),
                  _parameterManager.Get("AutoUseThisSetting", ConstantVariables.SETTINGS_AUTO_USE_THIS),
                  _parameterManager.Get("AutoCallStatusSetting", ConstantVariables.SETTINGS_AUTO_CALL_STATUS),
                  _parameterManager.Get("DuplicatePreventionTimeoutSetting", ConstantVariables.SETTINGS_DUPLICATE_PREVENTION_TIMEOUT),
                  _parameterManager.Get("ShowMapviewTabOnRightSectionSetting", ConstantVariables.SETTINGS_SHOW_MAPVIEW_ON_RIGHT_SECTION),
                  _parameterManager.Get("ShowAddressOnMapviewTabSetting", ConstantVariables.SETTINGS_SHOW_ADDRESS_ON_MAPVIEW_TAB),
                  _parameterManager.Get("HighlightActiveClosestBusZoneSetting", ConstantVariables.SETTINGS_HIGHLIGHT_ACTIVE_CLOSEST_BUS_ZONE),
                  _parameterManager.Get("AutoLogoutIdleUsersSetting", ConstantVariables.SETTINGS_AUTO_LOGOUT_IDLE_USERS_SETTINGS)
                  ),
                      commandType: CommandType.StoredProcedure);
                getSettings = result.Read<GetSettingsResponseDto>().ToList();
                dbConnection.Close();
            }
            return getSettings;
        }
    }
}
