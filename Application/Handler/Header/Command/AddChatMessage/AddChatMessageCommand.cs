using DTO.Request.Header;
using DTO.Response;
using MediatR;

namespace Application.Handler.Header.Command.AddChatMessage
{
    public class AddChatMessageCommand :IRequest<CommonResultResponseDto<ChatRequestDto>>
    {
        public string ChatContactMemberId { get; set; }
        public string CreatedBy { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsMember { get; set; }
        public string TextMessage { get; set; }
    }
}
