using Application.Common.Response;
using DTO.Response;
using MediatR;
using DTO.Response.DailyReportRecipient;
using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;

namespace Application.Handler.DailyReportRecipient.Queries.GetAllDailyReportRecipient
{
    public class GetAllDailyReportRecipientQueryHandler : IRequestHandler<GetAllDailyReportRecipientQuery, CommonResultResponseDto<PaginatedList<GetAllDailyReportRecipientResponseDto>>>
    {
        private readonly IDailyReportRecipientService _dailyReportRecipientService;
        private readonly IRequestBuilder _requestBuilder;
        public GetAllDailyReportRecipientQueryHandler(IDailyReportRecipientService dailyReportRecipientService, IRequestBuilder requestBuilder)
        {
            _dailyReportRecipientService = dailyReportRecipientService;
            _requestBuilder = requestBuilder;
        }

        public async Task<CommonResultResponseDto<PaginatedList<GetAllDailyReportRecipientResponseDto>>> Handle(GetAllDailyReportRecipientQuery getAllDailyReportRecipientQuery, CancellationToken cancellationToken)
        {
            var filterModel = _requestBuilder.GetRequestBuilder(getAllDailyReportRecipientQuery.CommonRequest);
            return await _dailyReportRecipientService.GetAllDailyReportRecipient(filterModel.GetFilters(), getAllDailyReportRecipientQuery.CommonRequest, filterModel.GetSorts());
        }
    }
}
