using Application.Handler.Header.Dtos;
using Domain.Entities;
using DTO.Response.Header;

namespace Application.Abstraction.Repositories
{
    public   interface IDispatcherNotificationsRepository
    {
        Task<List<DispatchNotificationResponseDto>> GetEffectiveDispatchNotifications();
        Task<bool> DeleteDispatchNotification(int dispatchNotificationId);
        Task<CanSendNotificationsPermissionDto> CheckIfUserCanSendNotifications(int userId, string canSendNotifications);
        Task<DispatchNotificationDto> GetDispatchNotification(int id);
        Task<DispatcherNotification> SaveDispatchNotification(DispatcherNotification dispatcherNotification);

    }
}
