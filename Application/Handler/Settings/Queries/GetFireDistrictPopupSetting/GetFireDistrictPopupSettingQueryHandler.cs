using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.Settings;
using MediatR;

namespace Application.Handler.Settings.Queries.GetFireDistrictPopupSetting
{
    public class GetFireDistrictPopupSettingQueryHandler : IRequestHandler<GetFireDistrictPopupSettingQuery, CommonResultResponseDto<FireDistrictPopupSettingResponseDto>>
    {
        private readonly ISettingsService _settingsService;
        public GetFireDistrictPopupSettingQueryHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<FireDistrictPopupSettingResponseDto>> Handle(GetFireDistrictPopupSettingQuery request, CancellationToken cancellationToken)
        {
            return await _settingsService.GetFireDistrictPopupSetting();
        }
    }
}
