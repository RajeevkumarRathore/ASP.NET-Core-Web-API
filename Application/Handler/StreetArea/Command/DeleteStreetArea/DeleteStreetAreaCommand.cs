using DTO.Response;
using MediatR;

namespace Application.Handler.StreetArea.Command.DeleteStreetArea
{
    public class DeleteStreetAreaCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int Id { get; set; }
    }
}
