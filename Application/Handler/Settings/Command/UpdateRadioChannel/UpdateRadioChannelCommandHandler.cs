using Application.Abstraction.Services;
using DTO.Request.Settings;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateRadioChannel
{
    public class UpdateRadioChannelCommandHandler : IRequestHandler<UpdateRadioChannelCommand, CommonResultResponseDto<string>>
    {
        private readonly ISettingsService _settingsService;
        public UpdateRadioChannelCommandHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(UpdateRadioChannelCommand updateRadioChannelCommand, CancellationToken cancellationToken)
        {
            return await _settingsService.UpdateRadioChannel(updateRadioChannelCommand.Adapt<UpdateRadioChannelRequestDto>());
        }
    }
}
