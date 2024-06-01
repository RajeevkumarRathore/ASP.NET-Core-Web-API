using DTO.Response;
using DTO.Response.Report;
using MediatR;

namespace Application.Handler.Reports.Queries.GetCallHistoryNotes
{
    public class GetCallHistoryNotesQuery:IRequest<CommonResultResponseDto<IList<GetCallHistoryNotesResponseDto>>>
    {
        public int ClientId { get; set; }
    }
}
