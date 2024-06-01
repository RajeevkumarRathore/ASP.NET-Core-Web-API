using Application.Abstraction.Services;
using DTO.Response;
using MediatR;

namespace Application.Handler.Header.Command.DeleteDispatchNotification
{
    public class DeleteDispatchNotificationCommandHandler : IRequestHandler<DeleteDispatchNotificationCommand, CommonResultResponseDto<string>>
    {
        private readonly IDispatcherNotificationsServices _dispatcherNotificationsServices;
        public DeleteDispatchNotificationCommandHandler(IDispatcherNotificationsServices dispatcherNotificationsServices)
        {
           _dispatcherNotificationsServices = dispatcherNotificationsServices;
        }

        public async Task<CommonResultResponseDto<string>> Handle(DeleteDispatchNotificationCommand  deleteDispatchNotificationCommand, CancellationToken cancellationToken)
        {
            return await _dispatcherNotificationsServices.DeleteDispatchNotification(deleteDispatchNotificationCommand.Id);
        }
    }
}
