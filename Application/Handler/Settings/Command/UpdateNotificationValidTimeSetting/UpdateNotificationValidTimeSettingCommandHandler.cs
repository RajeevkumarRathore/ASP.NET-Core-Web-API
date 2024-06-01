using Application.Abstraction.Services;
using Domain.Entities;
using DTO.Request.Settings;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateNotificationValidTimeSetting
{
    public class UpdateNotificationValidTimeSettingCommandHandler : IRequestHandler<UpdateNotificationValidTimeSettingCommand, CommonResultResponseDto<Setting>>
    {
        private readonly ISettingsService _settingsService;
        public UpdateNotificationValidTimeSettingCommandHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<Setting>> Handle(UpdateNotificationValidTimeSettingCommand updateNotificationValidTimeSettingCommand, CancellationToken cancellationToken)
        {
            return await _settingsService.UpdateNotificationValidTimeSetting(updateNotificationValidTimeSettingCommand.Adapt<UpdateNotificationValidTimeSettingRequestDto>());
        }
    }
}
