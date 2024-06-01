using DTO.Response.Areas;
using DTO.Response;
using MediatR;

namespace Application.Handler.Areas.Command.CreateUpdateCommand
{
    public class CreateUpdateAreasCommand : IRequest<CommonResultResponseDto<CreateUpdateAreasResponseDto>>
    {
        public int Id { get; set; }
        public string AreaName { get; set; }
        public string ZipCode { get; set; }
        public string CityName { get; set; }
        public bool? FireDistrict { get; set; }
    }
}
