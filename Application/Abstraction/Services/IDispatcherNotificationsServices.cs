using Domain.Entities;
using DTO.Request.Header;
using DTO.Response;
using DTO.Response.Header;

namespace Application.Abstraction.Services
{
    public interface IDispatcherNotificationsServices
    {
        Task<CommonResultResponseDto<List<DispatchNotificationResponseDto>>> GetEffectiveDispatchNotifications();
        Task<CommonResultResponseDto<string>> DeleteDispatchNotification(int dispatchNotificationId);
        Task<CommonResultResponseDto<NotificationSendRequestDto>> SendAlertNotification(NotificationSendRequestDto notificationSendRequestDto);
        Task<CommonResultResponseDto<DispatcherNotification>> SaveDispatchNotification(DispatchNotificationRequestDto dispatchNotificationRequest);
    }
}
