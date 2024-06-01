using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.Header;
using MediatR;

namespace Application.Handler.Header.Queries.GetGroupChatByExpertisesId
{
    public class GetGroupChatByExpertisesIdQueryHandler : IRequestHandler<GetGroupChatByExpertisesIdQuery, CommonResultResponseDto<IList<ChatMessageHistoryResponseDto>>>
    {
        private readonly IPhoneService _phoneService;
        public GetGroupChatByExpertisesIdQueryHandler(IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }
        public async Task<CommonResultResponseDto<IList<ChatMessageHistoryResponseDto>>> Handle(GetGroupChatByExpertisesIdQuery getGroupChatByExpertisesIdQuery, CancellationToken cancellationToken)
        {
            return await _phoneService.GetGroupChatByExpertisesId(getGroupChatByExpertisesIdQuery.expertisesId);
        }
    }
}
