using Application.Abstraction.Services;
using Application.Handler.Header.Command.SendAlertNotification;
using Domain.Entities;
using DTO.Request.Header;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Header.Command.SaveDispatchNotification
{
    public class SaveDispatchNotificationCommandHandler : IRequestHandler<SaveDispatchNotificationCommand, CommonResultResponseDto<DispatcherNotification>>
    {
        private readonly IDispatcherNotificationsServices _dispatcherNotificationsServices;
        public SaveDispatchNotificationCommandHandler(IDispatcherNotificationsServices dispatcherNotificationsServices)
        {
            _dispatcherNotificationsServices = dispatcherNotificationsServices;
        }
        public async Task<CommonResultResponseDto<DispatcherNotification>> Handle(SaveDispatchNotificationCommand saveDispatchNotificationCommand, CancellationToken cancellationToken)
        {
            return await _dispatcherNotificationsServices.SaveDispatchNotification(saveDispatchNotificationCommand.Adapt<DispatchNotificationRequestDto>());
        }
    }
}
