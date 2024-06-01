using Application.Common.Response;
using DTO.Response;
using MediatR;
using DTO.Response.Places;
using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;

namespace Application.Handler.Places.Queries
{
    public class GetAllPlacesQueryHandler : IRequestHandler<GetAllPlacesQuery, CommonResultResponseDto<PaginatedList<GetAllPlacesResponseDto>>>
    {
        private readonly IPlaceService _placeService ;
        private readonly IRequestBuilder _requestBuilder;
        public GetAllPlacesQueryHandler(IPlaceService placeService, IRequestBuilder requestBuilder)
        {
            _placeService = placeService;
            _requestBuilder = requestBuilder;
        }

        public async Task<CommonResultResponseDto<PaginatedList<GetAllPlacesResponseDto>>> Handle(GetAllPlacesQuery getAllPlacesQuery, CancellationToken cancellationToken)
        {
            var filterModel = _requestBuilder.GetRequestBuilder(getAllPlacesQuery.CommonRequest);
            return await _placeService.GetAllPlaces(filterModel.GetFilters(), getAllPlacesQuery.CommonRequest, filterModel.GetSorts());
        }
    }
}
