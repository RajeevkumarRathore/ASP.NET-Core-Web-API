using Application.Abstraction.Services;
using Domain.Entities;
using DTO.Request.Settings;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Settings.Command.SaveAutoLogoutSettings
{
    public class SaveAutoLogoutSettingsCommandHandler : IRequestHandler<SaveAutoLogoutSettingsCommand, CommonResultResponseDto<Setting>>
    {
        private readonly ISettingsService _settingsService;
        public SaveAutoLogoutSettingsCommandHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<Setting>> Handle(SaveAutoLogoutSettingsCommand saveAutoLogoutSettingsCommand, CancellationToken cancellationToken)
        {
            return await _settingsService.SaveAutoLogoutSettings(saveAutoLogoutSettingsCommand.Adapt<SaveAutoLogoutSettingsRequestDto>());
        }
    }
}
