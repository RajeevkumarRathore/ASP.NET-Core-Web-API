using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using DTO.Response.Report;
using MediatR;

namespace Application.Handler.Reports.Queries.GetMembersSummaryForReport
{
    public class GetMembersSummaryForReportQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<MemberReportSummaryResult>>>
    {
        public int year { get; set; }
        public bool isNSCoordinator { get; set; }
        public int? emergencyType { get; set; }
        public ServerRowsRequest CommonRequest { get; set; }
    }
}
