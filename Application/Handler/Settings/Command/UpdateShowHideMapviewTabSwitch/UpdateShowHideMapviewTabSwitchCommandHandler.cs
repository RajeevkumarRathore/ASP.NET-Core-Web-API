using Application.Abstraction.Services;
using Domain.Entities;
using DTO.Request.Settings;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateShowHideMapviewTabSwitch
{
    public class UpdateShowHideMapviewTabSwitchCommandHandler : IRequestHandler<UpdateShowHideMapviewTabSwitchCommand, CommonResultResponseDto<Setting>>
    {
        private readonly ISettingsService _settingsService;
        public UpdateShowHideMapviewTabSwitchCommandHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<Setting>> Handle(UpdateShowHideMapviewTabSwitchCommand updateShowHideMapviewTabSwitchCommand, CancellationToken cancellationToken)
        {
            return await _settingsService.UpdateShowHideMapviewTabSwitch(updateShowHideMapviewTabSwitchCommand.Adapt<UpdateShowHideMapviewTabSwitchRequestDto>());
        }
    }
}
