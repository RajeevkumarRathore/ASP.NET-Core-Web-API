using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using DTO.Response.Report;
using MediatR;

namespace Application.Handler.Reports.Queries.MembersReportByDateRange
{
    public class GetMembersReportByDateRangeQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<GetMembersReportByDateRangeResponseDto>>>
    {
        public string fromTime { get; set; }
        public string toTime { get; set; }
        public string dayFromTime { get; set; }
        public string dayToTime { get; set; }
        public string nightFromTime { get; set; }
        public string nightToTime { get; set; }
        public bool byDate { get; set; }
        public bool isNSCoordinator { get; set; }
        public int? emergencyType { get; set; }
        public ServerRowsRequest CommonRequest { get; set; }
    }
}
