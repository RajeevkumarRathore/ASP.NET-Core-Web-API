using DTO.Response;
using MediatR;

namespace Application.Handler.ShortTextMessage.Command.DeleteTextMessage
{
    public class DeleteContactPersonCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int Id { get; set; }
    }
}
