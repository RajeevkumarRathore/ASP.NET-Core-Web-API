using Application.Abstraction.Services;
using Application.Common.Response;
using DTO.Request.Header;
using DTO.Response;
using DTO.Response.Header;
using Mapster;
using MediatR;

namespace Application.Handler.Header.Queries.GetInternalChat
{
    public class GetInternalChatQueryHandler : IRequestHandler<GetInternalChatQuery, CommonResultResponseDto<PaginatedList<ChatHistoryViewModel>>>
    {
        private readonly IPhoneService _phoneService;

        public GetInternalChatQueryHandler(IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }
        public async Task<CommonResultResponseDto<PaginatedList<ChatHistoryViewModel>>> Handle(GetInternalChatQuery  getInternalChatQuery, CancellationToken cancellationToken)
        {
            return await _phoneService.GetInternalChat(getInternalChatQuery.Adapt<ChatMessageHistoryRequestDto>());
        }
    }
}
