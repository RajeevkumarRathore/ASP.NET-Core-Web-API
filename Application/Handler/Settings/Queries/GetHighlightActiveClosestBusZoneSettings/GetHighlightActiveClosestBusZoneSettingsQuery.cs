using DTO.Response;
using DTO.Response.Settings;
using MediatR;

namespace Application.Handler.Settings.Queries.GetHighlightActiveClosestBusZoneSettings
{
    public class GetHighlightActiveClosestBusZoneSettingsQuery : IRequest<CommonResultResponseDto<GetHighlightActiveClosestBusZoneSettingsResponseDto>>
    {
        public bool IsEnabled { get; set; }
    }
}
