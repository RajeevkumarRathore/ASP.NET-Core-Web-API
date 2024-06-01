using Application.Abstraction.Services;
using Domain.Entities;
using DTO.Request.Settings;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateCanListenToOpenPhoneCallsTimeSettings
{
    public class UpdateCanListenToOpenPhoneCallsTimeSettingsCommandHandler : IRequestHandler<UpdateCanListenToOpenPhoneCallsTimeSettingsCommand, CommonResultResponseDto<Setting>>
    {
        private readonly ISettingsService _settingsService;
        public UpdateCanListenToOpenPhoneCallsTimeSettingsCommandHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<Setting>> Handle(UpdateCanListenToOpenPhoneCallsTimeSettingsCommand updateCanListenToOpenPhoneCallsTimeSettingsCommand, CancellationToken cancellationToken)
        {
            return await _settingsService.UpdateCanListenToOpenPhoneCallsTimeSettings(updateCanListenToOpenPhoneCallsTimeSettingsCommand.Adapt<UpdateCanListenToOpenPhoneCallsTimeSettingsRequestDto>());
        }
    }
}
