using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateNotificationValidTimeSetting
{
    public class UpdateNotificationValidTimeSettingCommand : IRequest<CommonResultResponseDto<Setting>>
    {
        public int ReplyTimeOut { get; set; }
    }
}
