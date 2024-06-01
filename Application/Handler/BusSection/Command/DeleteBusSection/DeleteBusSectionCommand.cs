using DTO.Response;
using MediatR;

namespace Application.Handler.BusSection.Command.DeleteBusSection
{
    public class DeleteBusSectionCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int Id { get; set; }
    }
}