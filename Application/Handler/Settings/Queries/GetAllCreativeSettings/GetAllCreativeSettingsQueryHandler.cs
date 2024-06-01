using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.Settings;
using MediatR;

namespace Application.Handler.Settings.Queries.GetAllCreativeSettings
{
    public class GetAllCreativeSettingsQueryHandler : IRequestHandler<GetAllCreativeSettingsQuery, CommonResultResponseDto<CreativeSettingsResponseDto>>
    {
        private readonly ISettingsService _settingsService;
        public GetAllCreativeSettingsQueryHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<CreativeSettingsResponseDto>> Handle(GetAllCreativeSettingsQuery request, CancellationToken cancellationToken)
        {
            return await _settingsService.GetAllCreativeSettings();
        }
    }
}
