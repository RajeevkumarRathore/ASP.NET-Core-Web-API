using DTO.Response;
using MediatR;
using DTO.Response.Cities;
using Application.Abstraction.Services;

namespace Application.Handler.Cities.Queries.GetCities
{
    public class GetCitiesQueryHandler : IRequestHandler<GetCitiesQuery, CommonResultResponseDto<IList<GetCitiesResponseDto>>>
    {
        private readonly ICitiesService _citiesService;
      
        public GetCitiesQueryHandler(ICitiesService citiesService)
        {
            _citiesService = citiesService;
           
        }

        public async Task<CommonResultResponseDto<IList<GetCitiesResponseDto>>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
        {
            return await _citiesService.GetCities();
        }
    }
}
