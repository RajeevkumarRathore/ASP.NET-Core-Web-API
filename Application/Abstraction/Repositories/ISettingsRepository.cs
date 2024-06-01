using Domain.Entities;
using DTO.Request.Settings;
using DTO.Response.Settings;

namespace Application.Abstraction.Repositories
{
    public interface ISettingsRepository
    {
        Task<Setting> UpdateJsonProperty(int id, string jsonProperties);
        Task<Setting> UpdateAutoDismissCallSettings(Setting setting);
        Task<DispatchUrlSettingResponseDto> GetBackUpAndLiveUrl(string purpose);
        Task<string> DismissAllActiveCalls();
        Task<Setting> UpdateClientInfoPageFontSizeSettings(Setting setting);
        Task<GetRadioChannelResponseDto> GetRadioChannel();
        Task<string> UpdateRadioChannel(UpdateRadioChannelRequestDto saveAutoLogoutSettingsRequestDto);
        Task<List<GetSettingsResponseDto>> GetAllSettings();
    }
}
