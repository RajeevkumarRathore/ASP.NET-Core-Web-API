using DTO.Response;
using MediatR;

namespace Application.Handler.BusSection.Command.CreateUpdateBusSection
{
    public class CreateUpdateBusSectionCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
