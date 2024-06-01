using Application.Common.Response;
using Application.Handler.Reports.Queries.MembersReportByDateRange;
using DTO.Response.Report;
using DTO.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Request.Report;
using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;
using Mapster;

namespace Application.Handler.Reports.Queries.GetCallHistoryShabbosHourly
{
    public class GetCallHistoryShabbosHourlyQueryHandler : IRequestHandler<GetCallHistoryShabbosHourlyQuery, CommonResultResponseDto<PaginatedList<GetCallHistoryShabbosHourlyResponseDto>>>
    {
        private readonly IReportService _reportService;
        private readonly IRequestBuilder _requestBuilder;
        public GetCallHistoryShabbosHourlyQueryHandler(IReportService reportService, IRequestBuilder requestBuilder)
        {
            _reportService = reportService;
            _requestBuilder = requestBuilder;
        }
        public async Task<CommonResultResponseDto<PaginatedList<GetCallHistoryShabbosHourlyResponseDto>>> Handle(GetCallHistoryShabbosHourlyQuery getCallHistoryShabbosHourlyQuery, CancellationToken cancellationToken)
        {
            var filterModel = _requestBuilder.GetRequestBuilder(getCallHistoryShabbosHourlyQuery);
            return await _reportService.GetCallHistoryShabbosHourly(filterModel.GetFilters(), getCallHistoryShabbosHourlyQuery, filterModel.GetSorts(), getCallHistoryShabbosHourlyQuery.Adapt<GetCallHistoryShabbosHourlyRequestDto>());
        }
    }
}
