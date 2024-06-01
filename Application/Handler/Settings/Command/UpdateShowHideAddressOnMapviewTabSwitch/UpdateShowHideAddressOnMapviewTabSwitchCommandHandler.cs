using Application.Abstraction.Services;
using Domain.Entities;
using DTO.Request.Settings;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateShowHideAddressOnMapviewTabSwitch
{
    public class UpdateShowHideAddressOnMapviewTabSwitchCommandHandler : IRequestHandler<UpdateShowHideAddressOnMapviewTabSwitchCommand, CommonResultResponseDto<Setting>>
    {
        private readonly ISettingsService _settingsService;
        public UpdateShowHideAddressOnMapviewTabSwitchCommandHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<Setting>> Handle(UpdateShowHideAddressOnMapviewTabSwitchCommand updateShowHideAddressOnMapviewTabSwitchCommand, CancellationToken cancellationToken)
        {
            return await _settingsService.UpdateShowHideAddressOnMapviewTabSwitch(updateShowHideAddressOnMapviewTabSwitchCommand.Adapt<UpdateShowHideAddressOnMapviewTabSwitchRequestDto>());
        }
    }
}
