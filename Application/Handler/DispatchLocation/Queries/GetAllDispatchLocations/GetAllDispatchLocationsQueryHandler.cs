using Application.Common.Response;
using DTO.Response;
using MediatR;
using DTO.Response.DispatchLocation;
using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;

namespace Application.Handler.DispatchLocation.Queries.GetAllDispatchLocations
{
    public class GetAllDispatchLocationsQueryHandler : IRequestHandler<GetAllDispatchLocationsQuery, CommonResultResponseDto<PaginatedList<DispatchLocationsResponseDto>>>
    {
        private readonly IDispatchLocationService _dispatchLocationService;
        private readonly IRequestBuilder _requestBuilder;
        public GetAllDispatchLocationsQueryHandler(IDispatchLocationService dispatchLocationService, IRequestBuilder requestBuilder)
        {
            _dispatchLocationService = dispatchLocationService;
            _requestBuilder = requestBuilder;
        }
        public async Task<CommonResultResponseDto<PaginatedList<DispatchLocationsResponseDto>>> Handle(GetAllDispatchLocationsQuery getAllDispatchLocationsQuery, CancellationToken cancellationToken)
        {
            var filterModel = _requestBuilder.GetRequestBuilder(getAllDispatchLocationsQuery.CommonRequest);
            return await _dispatchLocationService.GetAllDispatchLocations(filterModel.GetFilters(), getAllDispatchLocationsQuery.CommonRequest, filterModel.GetSorts());
        }
    }
}
