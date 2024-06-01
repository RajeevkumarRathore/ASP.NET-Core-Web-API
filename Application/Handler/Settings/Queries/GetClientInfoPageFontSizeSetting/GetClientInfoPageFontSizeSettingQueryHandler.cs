using DTO.Response;
using MediatR;
using Application.Abstraction.Services;
using DTO.Response.Settings;

namespace Application.Handler.Settings.Queries.GetClientInfoPageFontSizeSetting
{
    public class GetClientInfoPageFontSizeSettingQueryHandler : IRequestHandler<GetClientInfoPageFontSizeSettingQuery, CommonResultResponseDto<FontSizeSettingResponseDto>>
    {
        private readonly ISettingsService _settingsService;
        public GetClientInfoPageFontSizeSettingQueryHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<FontSizeSettingResponseDto>> Handle(GetClientInfoPageFontSizeSettingQuery request, CancellationToken cancellationToken)
        {
            return await _settingsService.GetClientInfoPageFontSizeSetting();
        }
    }
}
