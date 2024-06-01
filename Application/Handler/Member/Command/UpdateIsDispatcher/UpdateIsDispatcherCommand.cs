using DTO.Response;
using MediatR;
namespace Application.Handler.Member.Command.UpdateIsDispatcher
{
    public class UpdateIsDispatcherCommand : IRequest<CommonResultResponseDto<string>>
    {
        public Guid user_id { get; set; }
        public bool isDispatcher { get; set; }
    }
}
