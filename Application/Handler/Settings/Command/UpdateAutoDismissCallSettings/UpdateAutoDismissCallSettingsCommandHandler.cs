using Application.Abstraction.Services;
using Domain.Entities;
using DTO.Request.Settings;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateAutoDismissCallSettings
{
    public class UpdateAutoDismissCallSettingsCommandHandler : IRequestHandler<UpdateAutoDismissCallSettingsCommand, CommonResultResponseDto<Setting>>
    {
        private readonly ISettingsService _settingsService;
        public UpdateAutoDismissCallSettingsCommandHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<Setting>> Handle(UpdateAutoDismissCallSettingsCommand updateAutoDismissCallSettingsCommand, CancellationToken cancellationToken)
        {
            return await _settingsService.UpdateAutoDismissCallSettings(updateAutoDismissCallSettingsCommand.Adapt<UpdateAutoDismissCallSettingsRequestDto>());
        }
    }
}
