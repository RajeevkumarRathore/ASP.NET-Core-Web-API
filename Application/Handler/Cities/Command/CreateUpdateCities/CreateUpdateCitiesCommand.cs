using DTO.Response;
using MediatR;
using DTO.Response.Cities;

namespace Application.Handler.Cities.Command.CreateUpdateCities
{
    public class CreateUpdateCitiesCommand : IRequest<CommonResultResponseDto<CreateUpdateCitiesResponseDto>>
    {
        public int Id { get; set; }
        public string CityName { get; set; }
    }
}
