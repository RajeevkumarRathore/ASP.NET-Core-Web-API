using DTO.Request.Header;
using DTO.Response;
using MediatR;

namespace Application.Handler.Header.Command.SendAlertNotification
{
    public class SendAlertNotificationCommand : IRequest<CommonResultResponseDto<NotificationSendRequestDto>>
    {
        public string clientId { get; set; }
        public string maxCount { get; set; }
        public string source { get; set; }
        public string filter { get; set; }
        public string callType { get; set; }
        public string street { get; set; }
        public string message { get; set; }
        public int? alertMessageType { get; set; }
        public bool sendToCheif { get; set; }
        public string emergencyType { get; set; }
        public bool isNotificationTemporarySwitchOn { get; set; }
        public int loggedInUserId { get; set; }
        public string clickedButton { get; set; }
        public bool? isPreview { get; set; }
        public List<int> selectedExpertises { get; set; }
    }
}
