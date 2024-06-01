using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateNotificationPopupStatus
{
    public class UpdateNotificationPopupStatusCommand : IRequest<CommonResultResponseDto<Setting>>
    {
        public bool IsEnabled { get; set; }
    }
}
