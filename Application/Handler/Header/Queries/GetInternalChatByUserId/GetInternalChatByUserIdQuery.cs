using DTO.Response;
using DTO.Response.Header;
using MediatR;
namespace Application.Handler.Header.Queries.GetInternalChatByUserId
{
    public class GetInternalChatByUserIdQuery : IRequest<CommonResultResponseDto<List<ChatMessageHistoryResponseDto>>>
    {
        public string userId { get; set; }
        public string createdBy { get; set; }
    }
}
