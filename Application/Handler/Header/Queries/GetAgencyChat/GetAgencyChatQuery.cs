
using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response.Header;
using MediatR;

namespace Application.Handler.Header.Queries.GetAgencyChat
{
    public class GetAgencyChatQuery : IRequest<ChatHistoryViewModelRequestDto>
    {
        public int userId { get; set; }
        public int agencyId { get; set; }
        public string searchText { get; set; }
        public bool isMember { get; set; }
        public int startRow { get; set; }
        public int endRow { get; set; }
    }
}
