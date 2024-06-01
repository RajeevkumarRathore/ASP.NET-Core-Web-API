
using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;
using Application.Common.Response;
using Application.Handler.Header.Queries.GetInternalChat;
using DTO.Request.Header;
using DTO.Response.Header;
using Mapster;
using MediatR;

namespace Application.Handler.Header.Queries.GetAgencyChat
{
    public class GetAgencyChatQueryHandler : IRequestHandler<GetAgencyChatQuery, ChatHistoryViewModelRequestDto>
    {
        private readonly IPhoneService _phoneService;

        public GetAgencyChatQueryHandler(IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }
        public async Task<ChatHistoryViewModelRequestDto> Handle(GetAgencyChatQuery getAgencyChatQuery, CancellationToken cancellationToken)
        {
            return await _phoneService.GetAgencyChat(getAgencyChatQuery.Adapt<ChatMessageHistoryRequestDto>()); 
        }
    }
}
