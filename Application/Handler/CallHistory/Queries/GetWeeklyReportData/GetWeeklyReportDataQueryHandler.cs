using Application.Abstraction.Services;
using DTO.Request.ClientInfo;
using DTO.Response;
using MediatR;

namespace Application.Handler.CallHistory.Queries.GetWeeklyReportData
{
    public class GetWeeklyReportDataQueryHandler : IRequestHandler<GetWeeklyReportDataQuery, CommonResultResponseDto<IList<CallHistoryViewModel>>>
    {
        private readonly IClientService _clientService;
        public GetWeeklyReportDataQueryHandler(IClientService clientService)
        {
            _clientService = clientService;
        }
        public async Task<CommonResultResponseDto<IList<CallHistoryViewModel>>> Handle(GetWeeklyReportDataQuery request, CancellationToken cancellationToken)
        {
            return await _clientService.GetWeeklyReportData(request.StartDate, request.EndDate,request.SearchText,request.IsDispatchedCallsOnly,request.IsALSActivatedCallsOnly);
        }
    }
}
