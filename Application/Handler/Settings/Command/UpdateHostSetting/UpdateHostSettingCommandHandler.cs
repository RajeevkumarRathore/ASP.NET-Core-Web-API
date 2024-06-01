using Application.Abstraction.Services;
using Domain.Entities;
using DTO.Request.Settings;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateHostSetting
{
    public class UpdateHostSettingCommandHandler : IRequestHandler<UpdateHostSettingCommand, CommonResultResponseDto<Setting>>
    {
        private readonly ISettingsService _settingsService;
        public UpdateHostSettingCommandHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<Setting>> Handle(UpdateHostSettingCommand updateHostSettingCommand, CancellationToken cancellationToken)
        {
            return await _settingsService.UpdateHostSetting(updateHostSettingCommand.Adapt<UpdateHostSettingRequestDto>());
        }
    }
}
