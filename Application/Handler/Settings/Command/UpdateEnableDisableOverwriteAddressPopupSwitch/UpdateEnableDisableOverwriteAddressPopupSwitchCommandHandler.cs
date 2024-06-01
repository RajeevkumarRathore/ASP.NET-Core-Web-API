using Application.Abstraction.Services;
using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateEnableDisableOverwriteAddressPopupSwitch
{
    public class UpdateEnableDisableOverwriteAddressPopupSwitchCommandHandler : IRequestHandler<UpdateEnableDisableOverwriteAddressPopupSwitchCommand, CommonResultResponseDto<Setting>>
    {
        private readonly ISettingsService _settingsService;
        public UpdateEnableDisableOverwriteAddressPopupSwitchCommandHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<Setting>> Handle(UpdateEnableDisableOverwriteAddressPopupSwitchCommand updateEnableDisableOverwriteAddressPopupSwitchCommand, CancellationToken cancellationToken)
        {
            return await _settingsService.UpdateEnableDisableOverwriteAddressPopupSwitch(updateEnableDisableOverwriteAddressPopupSwitchCommand.IsEnabled);
        }
    }
}
