

namespace Application.Handler.Header.Dtos
{
    public class CanSendNotificationsPermissionDto
    {
        public int userId { get; set; }
        public int? userRoleId { get; set; }
        public bool canSendNotifications { get; set; }
    }
}
