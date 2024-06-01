using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;
using Application.Common.Response;
using DTO.Request.CallHistory;
using DTO.Request.ClientInfo;
using DTO.Response;
using Mapster;
using MediatR;
namespace Application.Handler.CallHistory.Queries.GetCallHistory
{
    public class GetCallHistoryQueryHandler : IRequestHandler<GetCallHistoryQuery, CommonResultResponseDto<PaginatedList<CallHistoryViewModel>>>
    {
        private readonly IClientService _clientService;
        private readonly IRequestBuilder _requestBuilder;
        public GetCallHistoryQueryHandler(IClientService clientService, IRequestBuilder requestBuilder)
        {
            _clientService = clientService;
            _requestBuilder = requestBuilder;
        }

        public async  Task<CommonResultResponseDto<PaginatedList<CallHistoryViewModel>>> Handle(GetCallHistoryQuery getCallHistoryQuery, CancellationToken cancellationToken)
        {
            bool hasReportsMenuPermission = false;
            var filterModel = _requestBuilder.GetRequestBuilder(getCallHistoryQuery);
            return await _clientService.GetCallHistory(getCallHistoryQuery.Adapt<GetCallHistoryViewModelRequestDto>(), hasReportsMenuPermission, getCallHistoryQuery.CommonRequest, filterModel.GetFilters(), filterModel.GetSorts());
        }
    }
}
