using DTO.Response.CallHistory;
using DTO.Response;
using MediatR;

namespace Application.Handler.CallHistory.Queries.GetMemberCallHistoryReportByBadge
{
    public class GetMemberCallHistoryReportByBadgeQuery : IRequest<CommonResultResponseDto<GetMemberCallHistoryReportByBadgeResponseDto>>
    {
        public string badgeNumber { get; set; }
        public DateTime fromTime { get; set; }
        public DateTime toTime { get; set; }
    }
}
