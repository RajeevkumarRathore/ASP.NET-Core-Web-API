using Application.Common.Response;
using DTO.Response;
using DTO.Response.Header;
using MediatR;

namespace Application.Handler.Header.Queries.GetGroupChatByExpertisesId
{
    public class GetGroupChatByExpertisesIdQuery : IRequest<CommonResultResponseDto<IList<ChatMessageHistoryResponseDto>>>
    {
        public string expertisesId { get; set; }
    }
}
