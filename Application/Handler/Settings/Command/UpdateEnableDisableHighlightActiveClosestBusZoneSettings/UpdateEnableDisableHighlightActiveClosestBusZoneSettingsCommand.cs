using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateEnableDisableHighlightActiveClosestBusZoneSettings
{
    public class UpdateEnableDisableHighlightActiveClosestBusZoneSettingsCommand : IRequest<CommonResultResponseDto<Setting>>
    {
        public bool IsEnabled { get; set; }
    }
}
