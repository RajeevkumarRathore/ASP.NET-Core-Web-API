using Application.Abstraction.Services;
using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateEnableDisableAutoUseThisSwitch
{
    public class UpdateEnableDisableAutoUseThisSwitchCommandHandler : IRequestHandler<UpdateEnableDisableAutoUseThisSwitchCommand, CommonResultResponseDto<Setting>>
    {
        private readonly ISettingsService _settingsService;
        public UpdateEnableDisableAutoUseThisSwitchCommandHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<Setting>> Handle(UpdateEnableDisableAutoUseThisSwitchCommand updateEnableDisableAutoUseThisSwitchCommand, CancellationToken cancellationToken)
        {
            return await _settingsService.UpdateEnableDisableAutoUseThisSwitch(updateEnableDisableAutoUseThisSwitchCommand.IsEnabled);
        }
    }
}
