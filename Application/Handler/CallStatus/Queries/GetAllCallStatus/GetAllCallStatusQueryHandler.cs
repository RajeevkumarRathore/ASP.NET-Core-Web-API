using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;
using Application.Common.Response;
using DTO.Response;
using DTO.Response.CallStatus;
using MediatR;

namespace Application.Handler.CallStatus.Queries.GetAllCallStatus
{
    public class GetAllCallStatusQueryHandler : IRequestHandler<GetAllCallStatusQuery, CommonResultResponseDto<PaginatedList<CallStatusResponseDto>>>
    {
        private readonly ICallStatusService _callStatusService;
        private readonly IRequestBuilder _requestBuilder;
        public GetAllCallStatusQueryHandler(ICallStatusService callStatusService, IRequestBuilder requestBuilder)
        {
            _callStatusService = callStatusService;
            _requestBuilder = requestBuilder;
        }
        public async Task<CommonResultResponseDto<PaginatedList<CallStatusResponseDto>>> Handle(GetAllCallStatusQuery getAllCallStatusQuery, CancellationToken cancellationToken)
        {
            var filterModel = _requestBuilder.GetRequestBuilder(getAllCallStatusQuery.CommonRequest);
            return await _callStatusService.GetAllCallStatus(filterModel.GetFilters(), getAllCallStatusQuery.CommonRequest, filterModel.GetSorts());
        }
    }
}
