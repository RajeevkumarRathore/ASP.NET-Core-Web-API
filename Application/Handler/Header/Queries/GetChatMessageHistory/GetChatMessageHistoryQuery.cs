using Application.Common.Response;
using DTO.Response;
using MediatR;

namespace Application.Handler.Contact.Queries.GetChatAll
{
    public class GetChatMessageHistoryQuery:IRequest<CommonResultResponseDto<PaginatedList<ChatHistoryDto>>>
    {
        public string SearchText { get; set; }
        public bool IsMember { get; set; }
        public int StartRow { get; set; }
        public int EndRow { get; set; }
    }
}
