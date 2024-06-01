using Application.Common.Response;
using DTO.Response;
using MediatR;
using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;
using DTO.Response.StatusInfos;

namespace Application.Handler.StatusInfo.Queries.GetAllStatusInfo
{
    public class GetAllStatusInfoQueryHandler : IRequestHandler<GetAllStatusInfoQuery, CommonResultResponseDto<PaginatedList<StatusInfosResponseDto>>>
    {
        private readonly IStatusInfoService _statusInfoService;
        private readonly IRequestBuilder _requestBuilder;
        public GetAllStatusInfoQueryHandler(IStatusInfoService statusInfoService, IRequestBuilder requestBuilder)
        {
            _statusInfoService = statusInfoService;
            _requestBuilder = requestBuilder;
        }
        public async Task<CommonResultResponseDto<PaginatedList<StatusInfosResponseDto>>> Handle(GetAllStatusInfoQuery getAllStatusInfoQuery, CancellationToken cancellationToken)
        {
            var filterModel = _requestBuilder.GetRequestBuilder(getAllStatusInfoQuery.CommonRequest);
            return await _statusInfoService.GetAllStatusInfo(filterModel.GetFilters(), getAllStatusInfoQuery.CommonRequest, filterModel.GetSorts());
        }
    }
}
