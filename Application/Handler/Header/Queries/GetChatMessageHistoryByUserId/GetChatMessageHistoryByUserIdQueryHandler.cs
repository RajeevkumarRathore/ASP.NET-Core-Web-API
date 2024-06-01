using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.Header;
using MediatR;

namespace Application.Handler.Contact.Queries.GetChatHistory
{
    public class GetChatMessageHistoryByUserIdQueryHandler : IRequestHandler<GetChatMessageHistoryByUserIdQuery,CommonResultResponseDto<List<ChatMessageHistoryResponseDto>>>
    {
        private readonly IChatMessageHistoryService  _chatMessageHistoryService;
        public GetChatMessageHistoryByUserIdQueryHandler(IChatMessageHistoryService chatMessageHistoryService)
        {
            _chatMessageHistoryService = chatMessageHistoryService;
        }
        public async Task<CommonResultResponseDto<List<ChatMessageHistoryResponseDto>>> Handle(GetChatMessageHistoryByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _chatMessageHistoryService.GetChatMessageHistoryByUserId(request.chatUserId, request.phone);
        }
    }
}
