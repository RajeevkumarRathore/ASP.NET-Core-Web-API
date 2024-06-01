using DTO.Response;
using MediatR;
using Domain.Entities;
using Application.Abstraction.Services;
using DTO.Request.Settings;
using Mapster;

namespace Application.Handler.Settings.Command.UpdateDispatchAlertSettings
{
    public class UpdateDispatchAlertSettingsCommandHandler : IRequestHandler<UpdateDispatchAlertSettingsCommand, CommonResultResponseDto<Setting>>
    {
        private readonly ISettingsService _settingsService;
        public UpdateDispatchAlertSettingsCommandHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<Setting>> Handle(UpdateDispatchAlertSettingsCommand updateDispatchAlertSettingsCommand, CancellationToken cancellationToken)
        {
            return await _settingsService.UpdateDispatchAlertSettings(updateDispatchAlertSettingsCommand.Adapt<UpdateDispatchAlertSettingsRequestDto>());
        }
    }
}
