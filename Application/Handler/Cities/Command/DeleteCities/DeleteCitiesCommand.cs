using DTO.Response;
using MediatR;

namespace Application.Handler.Cities.Command.DeleteCities
{
    public class DeleteCitiesCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int Id { get; set; }
    }
}
