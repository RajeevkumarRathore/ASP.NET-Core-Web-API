using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;
using Application.Common.Response;
using Application.Handler.CallHistory.Queries.GetCallHistory;
using DTO.Request.CallHistory;
using DTO.Response;
using DTO.Response.CallHistory;
using Mapster;
using MediatR;

namespace Application.Handler.CallHistory.Queries.GetCallHistoryShabbos
{
    public class GetCallHistoryShabbosQueryHandler : IRequestHandler<GetCallHistoryShabbosQuery, CommonResultResponseDto<PaginatedList<GetCallHistoryShabbosResponseDto>>>
    {
        private readonly IClientService _clientService;
        private readonly IRequestBuilder _requestBuilder;
        public GetCallHistoryShabbosQueryHandler(IClientService clientService, IRequestBuilder requestBuilder)
        {
            _clientService = clientService;
            _requestBuilder = requestBuilder;
        }
        public async Task<CommonResultResponseDto<PaginatedList<GetCallHistoryShabbosResponseDto>>> Handle(GetCallHistoryShabbosQuery getCallHistoryShabbosQuery, CancellationToken cancellationToken)
        {
            bool hasReportsMenuPermission = false;
            var filterModel = _requestBuilder.GetRequestBuilder(getCallHistoryShabbosQuery);
            return await _clientService.GetCallHistoryShabbos(getCallHistoryShabbosQuery.Adapt<GetCallHistoryViewModelRequestDto>(), hasReportsMenuPermission, getCallHistoryShabbosQuery.CommonRequest, filterModel.GetFilters(), filterModel.GetSorts());
        }
    }
}
