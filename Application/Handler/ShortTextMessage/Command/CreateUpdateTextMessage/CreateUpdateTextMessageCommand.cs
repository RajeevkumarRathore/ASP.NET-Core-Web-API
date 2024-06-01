using DTO.Response;
using MediatR;

namespace Application.Handler.ShortTextMessage.Command.CreateUpdateTextMessage
{
    public class CreateUpdateTextMessageCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int Id { get; set; }
        public string ShortText { get; set; }
        public string FullText { get; set; }
        public string Type { get; set; }
    }
}
