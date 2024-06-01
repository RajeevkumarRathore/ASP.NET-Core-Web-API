using Application.Abstraction.Services;
using Domain.Entities;
using DTO.Request.Settings;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateNotificationPopupStatus
{
    public class UpdateNotificationPopupStatusCommandHandler : IRequestHandler<UpdateNotificationPopupStatusCommand, CommonResultResponseDto<Setting>>
    {
        private readonly ISettingsService _settingsService;
        public UpdateNotificationPopupStatusCommandHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<Setting>> Handle(UpdateNotificationPopupStatusCommand updateNotificationPopupStatusCommand, CancellationToken cancellationToken)
        {
            return await _settingsService.UpdateNotificationPopupStatus(updateNotificationPopupStatusCommand.Adapt<UpdateNotificationPopupStatusRequestDto>());
        }
    }
}
