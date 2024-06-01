using DTO.Response.Settings;
using DTO.Response;
using MediatR;
using Application.Abstraction.Services;

namespace Application.Handler.Settings.Queries.GetHostSetting
{
    public class GetHostSettingQueryHandler : IRequestHandler<GetHostSettingQuery, CommonResultResponseDto<HostSettingResponseDto>>
    {
        private readonly ISettingsService _settingsService;
        public GetHostSettingQueryHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<HostSettingResponseDto>> Handle(GetHostSettingQuery request, CancellationToken cancellationToken)
        {
            return await _settingsService.GetHostSetting();
        }
    }
}
