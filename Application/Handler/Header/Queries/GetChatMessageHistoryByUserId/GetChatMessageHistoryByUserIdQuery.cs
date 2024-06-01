using DTO.Response;
using DTO.Response.Header;
using MediatR;
namespace Application.Handler.Contact.Queries.GetChatHistory
{
    public class GetChatMessageHistoryByUserIdQuery: IRequest<CommonResultResponseDto<List<ChatMessageHistoryResponseDto>>>
    {
        public string chatUserId { get; set; }
        public string phone { get; set; }
    }
}
