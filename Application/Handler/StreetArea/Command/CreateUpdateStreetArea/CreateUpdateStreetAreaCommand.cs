using DTO.Response;
using MediatR;
using DTO.Response.StreetArea;

namespace Application.Handler.StreetArea.Command.CreateUpdateStreetArea
{
    public class CreateUpdateStreetAreaCommand : IRequest<CommonResultResponseDto<CreateUpdateStreetAreaResponseDto>>
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public string AreaName { get; set; }
        public string? CityName { get; set; }
        public string? Zip { get; set; }
        public string StreetNumber { get; set; }
    }
}
