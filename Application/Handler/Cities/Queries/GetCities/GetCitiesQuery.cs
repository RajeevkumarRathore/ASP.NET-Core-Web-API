using DTO.Response;
using MediatR;
using DTO.Response.Cities;

namespace Application.Handler.Cities.Queries.GetCities
{
    public class GetCitiesQuery : IRequest<CommonResultResponseDto<IList<GetCitiesResponseDto>>>
    {
    }
}
