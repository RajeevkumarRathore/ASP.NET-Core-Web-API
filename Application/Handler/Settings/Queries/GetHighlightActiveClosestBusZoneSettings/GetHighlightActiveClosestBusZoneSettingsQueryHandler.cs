using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.Settings;
using MediatR;

namespace Application.Handler.Settings.Queries.GetHighlightActiveClosestBusZoneSettings
{
    public class GetHighlightActiveClosestBusZoneSettingsQueryHandler : IRequestHandler<GetHighlightActiveClosestBusZoneSettingsQuery, CommonResultResponseDto<GetHighlightActiveClosestBusZoneSettingsResponseDto>>
    {
        private readonly ISettingsService _settingsService;
        public GetHighlightActiveClosestBusZoneSettingsQueryHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<GetHighlightActiveClosestBusZoneSettingsResponseDto>> Handle(GetHighlightActiveClosestBusZoneSettingsQuery request, CancellationToken cancellationToken)
        {
            return await _settingsService.GetHighlightActiveClosestBusZoneSettings();
        }
    }
}
