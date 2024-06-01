using DTO.Response.Settings;
using DTO.Response;
using MediatR;
using Application.Abstraction.Services;

namespace Application.Handler.Settings.Queries.GetCountyCallsSetting
{
    public class GetCountyCallsSettingQueryHandler : IRequestHandler<GetCountyCallsSettingQuery, CommonResultResponseDto<CountyCallsResponseDto>>
    {
        private readonly ISettingsService _settingsService;
        public GetCountyCallsSettingQueryHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<CountyCallsResponseDto>> Handle(GetCountyCallsSettingQuery request, CancellationToken cancellationToken)
        {
            return await _settingsService.GetCountyCallsSetting();
        }
    }
}
