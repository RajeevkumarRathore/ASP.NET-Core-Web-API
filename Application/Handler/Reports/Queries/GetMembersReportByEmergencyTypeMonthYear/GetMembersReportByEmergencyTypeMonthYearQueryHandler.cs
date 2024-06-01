
using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;
using Application.Common.Response;
using DTO.Response;
using DTO.Response.Report;
using MediatR;

namespace Application.Handler.Reports.Queries.GetMembersReportByEmergencyTypeMonthYear
{
    public class GetMembersReportByEmergencyTypeMonthYearQueryHandler : IRequestHandler<GetMembersReportByEmergencyTypeMonthYearQuery, CommonResultResponseDto<PaginatedList<GetMembersReportByDateRangeResponseDto>>>
    {
        private readonly IReportService _reportService;
        private readonly IRequestBuilder _requestBuilder;
        public GetMembersReportByEmergencyTypeMonthYearQueryHandler(IReportService reportService,IRequestBuilder requestBuilder)
        {
                _reportService = reportService;
              _requestBuilder = requestBuilder;
        }
        public async Task<CommonResultResponseDto<PaginatedList<GetMembersReportByDateRangeResponseDto>>> Handle(GetMembersReportByEmergencyTypeMonthYearQuery getMembersReportByEmergencyTypeMonthYearQuery, CancellationToken cancellationToken)
        {
            var filterModel = _requestBuilder.GetRequestBuilder(getMembersReportByEmergencyTypeMonthYearQuery);
            return await _reportService.GetMembersReportByEmergencyTypeMonthYear(filterModel.GetFilters(), filterModel.GetSorts(),getMembersReportByEmergencyTypeMonthYearQuery,getMembersReportByEmergencyTypeMonthYearQuery.month, getMembersReportByEmergencyTypeMonthYearQuery.year, getMembersReportByEmergencyTypeMonthYearQuery.emergencyType);
        }
    }
}
