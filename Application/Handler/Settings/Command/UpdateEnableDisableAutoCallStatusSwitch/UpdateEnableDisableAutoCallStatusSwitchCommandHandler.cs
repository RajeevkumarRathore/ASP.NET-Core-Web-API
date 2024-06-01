using Application.Abstraction.Services;
using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateEnableDisableAutoCallStatusSwitch
{
    public class UpdateEnableDisableAutoCallStatusSwitchCommandHandler : IRequestHandler<UpdateEnableDisableAutoCallStatusSwitchCommand, CommonResultResponseDto<Setting>>
    {
        private readonly ISettingsService _settingsService;
        public UpdateEnableDisableAutoCallStatusSwitchCommandHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<Setting>> Handle(UpdateEnableDisableAutoCallStatusSwitchCommand updateEnableDisableAutoCallStatusSwitchCommand, CancellationToken cancellationToken)
        {
            return await _settingsService.UpdateEnableDisableAutoCallStatusSwitch(updateEnableDisableAutoCallStatusSwitchCommand.IsEnabled);
        }
    }
}
