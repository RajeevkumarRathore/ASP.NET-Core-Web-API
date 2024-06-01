using Application.Abstraction.Services;
using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateEnableDisableAutoDismissCallSwitch
{
    public class UpdateEnableDisableAutoDismissCallSwitchCommandHandler : IRequestHandler<UpdateEnableDisableAutoDismissCallSwitchCommand, CommonResultResponseDto<Setting>>
    {
        private readonly ISettingsService _settingsService;
        public UpdateEnableDisableAutoDismissCallSwitchCommandHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<Setting>> Handle(UpdateEnableDisableAutoDismissCallSwitchCommand updateEnableDisableAutoDismissCallSwitchCommand, CancellationToken cancellationToken)
        {
            return await _settingsService.UpdateEnableDisableAutoDismissCallSwitch(updateEnableDisableAutoDismissCallSwitchCommand.IsEnabled);
        }
    }
}
