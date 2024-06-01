using DTO.Response.Header;
using MediatR;

namespace Application.Handler.Header.Queries.GetAgencyChatById
{
    public class GetAgencyChatByIdQuery : IRequest<IList<ChatMessageHistoryResponseDto>>
    {
        public string Id { get; set; }
    }
}
