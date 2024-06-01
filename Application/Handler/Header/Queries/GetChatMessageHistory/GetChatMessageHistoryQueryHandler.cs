using Application.Abstraction.Services;
using Application.Common.Response;
using DTO.Request.Header;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Contact.Queries.GetChatAll
{
    public class GetChatMessageHistoryQueryHandler : IRequestHandler<GetChatMessageHistoryQuery, CommonResultResponseDto<PaginatedList<ChatHistoryDto>>>
    {
        private readonly IPhoneService _phoneService;
        public GetChatMessageHistoryQueryHandler(IPhoneService  phoneService)
        {
            _phoneService = phoneService;
        }

        public async Task<CommonResultResponseDto<PaginatedList<ChatHistoryDto>>> Handle(GetChatMessageHistoryQuery getChatAllQuery, CancellationToken cancellationToken)
        {
            return await _phoneService.GetChatMessageHistory(getChatAllQuery.Adapt<GetChatAllRequestDto>());
        }
       
    }
}
