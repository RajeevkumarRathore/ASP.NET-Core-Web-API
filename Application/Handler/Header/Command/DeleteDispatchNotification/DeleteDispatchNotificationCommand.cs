using DTO.Response;
using MediatR;

namespace Application.Handler.Header.Command.DeleteDispatchNotification
{
    public class DeleteDispatchNotificationCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int Id { get; set; }
    }
}
