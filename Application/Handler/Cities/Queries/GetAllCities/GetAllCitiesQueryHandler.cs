using Application.Common.Response;
using DTO.Response;
using MediatR;
using DTO.Response.Cities;
using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;

namespace Application.Handler.Cities.Queries.GetAllCities
{
    public class GetAllCitiesQueryHandler : IRequestHandler<GetAllCitiesQuery, CommonResultResponseDto<PaginatedList<GetAllCitiesResponseDto>>>
    {
        private readonly ICitiesService _citiesService;
        private readonly IRequestBuilder _requestBuilder;
        public GetAllCitiesQueryHandler(ICitiesService citiesService, IRequestBuilder requestBuilder)
        {
            _citiesService = citiesService;
            _requestBuilder = requestBuilder;
        }
        public async Task<CommonResultResponseDto<PaginatedList<GetAllCitiesResponseDto>>> Handle(GetAllCitiesQuery getAllCitiesQuery, CancellationToken cancellationToken)
        {

            var filterModel = _requestBuilder.GetRequestBuilder(getAllCitiesQuery.CommonRequest);
            return await _citiesService.GetAllCities(filterModel.GetFilters(), getAllCitiesQuery.CommonRequest, filterModel.GetSorts());
        }
    }
}
