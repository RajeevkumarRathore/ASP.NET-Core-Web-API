
using Application.Abstraction.Services;
using Application.Handler.Header.Queries.GetGroupChatByExpertisesId;
using DTO.Response.Header;
using MediatR;

namespace Application.Handler.Header.Queries.GetAgencyChatById
{
    public class GetAgencyChatByIdQueryHandler : IRequestHandler<GetAgencyChatByIdQuery, IList<ChatMessageHistoryResponseDto>>
    {
        private readonly IPhoneService _phoneService;
        public GetAgencyChatByIdQueryHandler(IPhoneService phoneService)
        {
                _phoneService = phoneService;   
        }
        public async Task<IList<ChatMessageHistoryResponseDto>> Handle(GetAgencyChatByIdQuery getAgencyChatByIdQuery, CancellationToken cancellationToken)
        {
            return await _phoneService.GetAgencyChatById(getAgencyChatByIdQuery.Id);
        }
    }
}
