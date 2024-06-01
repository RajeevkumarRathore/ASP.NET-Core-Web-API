using Application.Abstraction.Services;
using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateAllowToTransferCallSwitch
{
    public class UpdateAllowToTransferCallSwitchCommandHandler : IRequestHandler<UpdateAllowToTransferCallSwitchCommand, CommonResultResponseDto<Setting>>
    {
        private readonly ISettingsService _settingsService;
        public UpdateAllowToTransferCallSwitchCommandHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<Setting>> Handle(UpdateAllowToTransferCallSwitchCommand updateAllowToTransferCallSwitchCommand, CancellationToken cancellationToken)
        {
            return await _settingsService.UpdateAllowToTransferCallSwitch(updateAllowToTransferCallSwitchCommand.IsEnabled);
        }
    }
}
