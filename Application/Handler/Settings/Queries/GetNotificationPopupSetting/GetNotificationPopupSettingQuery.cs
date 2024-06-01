using DTO.Response;
using DTO.Response.Settings;
using MediatR;

namespace Application.Handler.Settings.Queries.GetNotificationPopupSetting
{
    public class GetNotificationPopupSettingQuery : IRequest<CommonResultResponseDto<NotificationPopupResponseDto>>
    {
    }
}
