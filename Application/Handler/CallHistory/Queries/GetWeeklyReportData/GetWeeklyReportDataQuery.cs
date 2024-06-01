using DTO.Request.ClientInfo;
using DTO.Response;
using MediatR;


namespace Application.Handler.CallHistory.Queries.GetWeeklyReportData
{
    public class GetWeeklyReportDataQuery : IRequest<CommonResultResponseDto<IList<CallHistoryViewModel>>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SearchText { get; set; }
        public bool IsDispatchedCallsOnly { get; set; }
        public bool IsALSActivatedCallsOnly { get; set; }
    }
}