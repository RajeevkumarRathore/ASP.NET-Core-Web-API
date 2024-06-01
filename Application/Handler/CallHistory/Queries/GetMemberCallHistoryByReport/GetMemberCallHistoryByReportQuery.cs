using DTO.Response.CallHistory;
using DTO.Response;
using MediatR;

namespace Application.Handler.CallHistory.Queries.GetMemberCallHistoryByReport
{
    public class GetMemberCallHistoryByReportQuery : IRequest<CommonResultResponseDto<List<GetMemberCallHistoryReportResponseDto>>>
    {
        public string badgeNumber { get; set; }
        public string fromTime { get; set; }
        public string toTime { get; set; }
        public bool isMember { get; set; }
        public bool isShabbos { get; set; }
        public string hour { get; set; }
    }
}
