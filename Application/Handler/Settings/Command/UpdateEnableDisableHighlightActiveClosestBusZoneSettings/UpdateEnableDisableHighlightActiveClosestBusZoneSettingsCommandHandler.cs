using Application.Abstraction.Services;
using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateEnableDisableHighlightActiveClosestBusZoneSettings
{
    public class UpdateEnableDisableHighlightActiveClosestBusZoneSettingsCommandHandler : IRequestHandler<UpdateEnableDisableHighlightActiveClosestBusZoneSettingsCommand, CommonResultResponseDto<Setting>>
    {
        private readonly ISettingsService _settingsService;
        public UpdateEnableDisableHighlightActiveClosestBusZoneSettingsCommandHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<Setting>> Handle(UpdateEnableDisableHighlightActiveClosestBusZoneSettingsCommand updateEnableDisableHighlightActiveClosestBusZoneSettingsCommand, CancellationToken cancellationToken)
        {
            return await _settingsService.UpdateEnableDisableHighlightActiveClosestBusZoneSettings(updateEnableDisableHighlightActiveClosestBusZoneSettingsCommand.IsEnabled);
        }
    }
}
