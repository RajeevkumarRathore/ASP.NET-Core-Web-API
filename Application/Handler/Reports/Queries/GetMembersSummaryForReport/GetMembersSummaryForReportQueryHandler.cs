using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;
using Application.Common.Response;
using DTO.Response;
using DTO.Response.Report;
using MediatR;

namespace Application.Handler.Reports.Queries.GetMembersSummaryForReport
{
    public class GetMembersSummaryForReportQueryHandler : IRequestHandler<GetMembersSummaryForReportQuery, CommonResultResponseDto<PaginatedList<MemberReportSummaryResult>>>
    {
        private readonly IReportService _reportService;
        private readonly IRequestBuilder _requestBuilder;
        public GetMembersSummaryForReportQueryHandler(IReportService reportService, IRequestBuilder requestBuilder)
        {
            _reportService = reportService;
            _requestBuilder = requestBuilder;
        }

        public async Task<CommonResultResponseDto<PaginatedList<MemberReportSummaryResult>>> Handle(GetMembersSummaryForReportQuery getMembersSummaryForReportQuery, CancellationToken cancellationToken)
        {
            var filterModel = _requestBuilder.GetRequestBuilder(getMembersSummaryForReportQuery);
            return await _reportService.GetMembersSummaryForReport(filterModel.GetFilters(), getMembersSummaryForReportQuery, filterModel.GetSorts(),getMembersSummaryForReportQuery.year,getMembersSummaryForReportQuery.isNSCoordinator,getMembersSummaryForReportQuery.emergencyType);
        }
    }
}
