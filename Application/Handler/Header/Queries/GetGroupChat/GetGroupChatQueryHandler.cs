using Application.Abstraction.Services;
using Application.Common.Response;
using DTO.Request.Header;
using DTO.Response;
using DTO.Response.Header;
using Mapster;
using MediatR;

namespace Application.Handler.Header.Queries.GetGroupChat
{
    public class GetGroupChatQueryHandler : IRequestHandler<GetGroupChatQuery, CommonResultResponseDto<PaginatedList<ChatHistoryViewModel>>>
    {
        private readonly IPhoneService _phoneService;
        public GetGroupChatQueryHandler(IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }
        public async Task<CommonResultResponseDto<PaginatedList<ChatHistoryViewModel>>> Handle(GetGroupChatQuery getGroupChatQuery, CancellationToken cancellationToken)
        {
            return await _phoneService.GetGroupChat(getGroupChatQuery.Adapt<ChatMessageHistoryRequestDto>());
        }
    }
}
