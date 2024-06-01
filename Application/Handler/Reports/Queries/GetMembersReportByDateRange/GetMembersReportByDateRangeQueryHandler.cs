using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;
using Application.Common.Response;
using DTO.Request.Report;
using DTO.Response;
using DTO.Response.Report;
using Mapster;
using MediatR;

namespace Application.Handler.Reports.Queries.MembersReportByDateRange
{
    public class GetMembersReportByDateRangeQueryHandler : IRequestHandler<GetMembersReportByDateRangeQuery, CommonResultResponseDto<PaginatedList<GetMembersReportByDateRangeResponseDto>>>
    {
        private readonly IReportService _reportService;
        private readonly IRequestBuilder _requestBuilder;
        public GetMembersReportByDateRangeQueryHandler(IReportService reportService, IRequestBuilder requestBuilder)
        {
            _reportService = reportService;
            _requestBuilder = requestBuilder;
        }
        
        public async Task<CommonResultResponseDto<PaginatedList<GetMembersReportByDateRangeResponseDto>>> Handle(GetMembersReportByDateRangeQuery getMembersReportByDateRangeQuery, CancellationToken cancellationToken)
        {
            var filterModel = _requestBuilder.GetRequestBuilder(getMembersReportByDateRangeQuery);
            return await _reportService.GetMembersReportByDateRange(filterModel.GetFilters(), getMembersReportByDateRangeQuery, filterModel.GetSorts(), getMembersReportByDateRangeQuery.Adapt<GetMembersReportByDateRangeRequestDto>());
        }
    }
}
