using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.Report;
using MediatR;


namespace Application.Handler.Reports.Queries.GetCallHistoryNotes
{
    public class GetCallHistoryNotesQueryHandler : IRequestHandler<GetCallHistoryNotesQuery, CommonResultResponseDto<IList<GetCallHistoryNotesResponseDto>>>
    {
        private readonly IReportService _reportService;
        public GetCallHistoryNotesQueryHandler(IReportService reportService)
        {
            _reportService = reportService;
        }
        public async Task<CommonResultResponseDto<IList<GetCallHistoryNotesResponseDto>>> Handle(GetCallHistoryNotesQuery getCallHistoryNotesQuery, CancellationToken cancellationToken)
        {
            return await _reportService.GetCallHistoryNotes(getCallHistoryNotesQuery.ClientId);
        }
    }
}
