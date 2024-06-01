using Application.Abstraction.Services;
using Domain.Entities;
using DTO.Request.Settings;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateDuplicatePreventionTimeoutSettings
{
    public class UpdateDuplicatePreventionTimeoutSettingsCommandHandler : IRequestHandler<UpdateDuplicatePreventionTimeoutSettingsCommand, CommonResultResponseDto<Setting>>
    {
        private readonly ISettingsService _settingsService;
        public UpdateDuplicatePreventionTimeoutSettingsCommandHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<Setting>> Handle(UpdateDuplicatePreventionTimeoutSettingsCommand updateDuplicatePreventionTimeoutSettingsCommand, CancellationToken cancellationToken)
        {
            return await _settingsService.UpdateDuplicatePreventionTimeoutSettings(updateDuplicatePreventionTimeoutSettingsCommand.Adapt<UpdateDuplicatePreventionTimeoutSettingsRequestDto>());
        }
    }
}
