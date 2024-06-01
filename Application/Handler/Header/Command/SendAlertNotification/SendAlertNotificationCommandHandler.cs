using Application.Abstraction.Services;
using DTO.Request.Header;
using DTO.Response;
using Mapster;
using MediatR;
namespace Application.Handler.Header.Command.SendAlertNotification
{
    public class SendAlertNotificationCommandHandler : IRequestHandler<SendAlertNotificationCommand, CommonResultResponseDto<NotificationSendRequestDto>>
    {
        private readonly IDispatcherNotificationsServices _dispatcherNotificationsServices;
        public SendAlertNotificationCommandHandler( IDispatcherNotificationsServices dispatcherNotificationsServices )
        {
           _dispatcherNotificationsServices = dispatcherNotificationsServices;
        }
        public async Task<CommonResultResponseDto<NotificationSendRequestDto>> Handle(SendAlertNotificationCommand sendAlertNotificationCommand , CancellationToken cancellationToken)
        {
            return await _dispatcherNotificationsServices.SendAlertNotification(sendAlertNotificationCommand.Adapt<NotificationSendRequestDto>());
        }
    }
}
