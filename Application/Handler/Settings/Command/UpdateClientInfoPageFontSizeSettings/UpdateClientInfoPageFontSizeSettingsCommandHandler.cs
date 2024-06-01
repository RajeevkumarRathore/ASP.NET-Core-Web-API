using Application.Abstraction.Services;
using Domain.Entities;
using DTO.Request.Settings;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateClientInfoPageFontSizeSettings
{
    public class UpdateClientInfoPageFontSizeSettingsCommandHandler : IRequestHandler<UpdateClientInfoPageFontSizeSettingsCommand, CommonResultResponseDto<Setting>>
    {
        private readonly ISettingsService _settingsService;
        public UpdateClientInfoPageFontSizeSettingsCommandHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<Setting>> Handle(UpdateClientInfoPageFontSizeSettingsCommand updateClientInfoPageFontSizeSettingsCommand, CancellationToken cancellationToken)
        {
            return await _settingsService.UpdateClientInfoPageFontSizeSettings(updateClientInfoPageFontSizeSettingsCommand.Adapt<UpdateClientInfoPageFontSizeSettingsRequestDto>());
        }
    }
}
