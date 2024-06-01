using Application.Common.Response;
using DTO.Response;
using MediatR;
using DTO.Response.UrgencyInfo;
using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;

namespace Application.Handler.UrgencyInfo.Queries.GetAllUrgencyInfo
{
    public class GetAllUrgencyInfoQueryHandler : IRequestHandler<GetAllUrgencyInfoQuery, CommonResultResponseDto<PaginatedList<UrgencyInfoResponseDto>>>
    {
        private readonly IUrgencyInfoService _urgencyInfoService;
        private readonly IRequestBuilder _requestBuilder;
        public GetAllUrgencyInfoQueryHandler(IUrgencyInfoService urgencyInfoService, IRequestBuilder requestBuilder)
        {
            _urgencyInfoService =  urgencyInfoService;
            _requestBuilder = requestBuilder;
        }
        public async Task<CommonResultResponseDto<PaginatedList<UrgencyInfoResponseDto>>> Handle(GetAllUrgencyInfoQuery getAllUrgencyInfoQuery, CancellationToken cancellationToken)
        {
            var filterModel = _requestBuilder.GetRequestBuilder(getAllUrgencyInfoQuery.CommonRequest);
            return await _urgencyInfoService.GetAllUrgencyInfo(filterModel.GetFilters(), getAllUrgencyInfoQuery.CommonRequest, filterModel.GetSorts());
        }
    }
}
