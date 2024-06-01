using DTO.Response;
using MediatR;

namespace Application.Handler.Places.Command.DeletePlace
{
    public class DeletePlaceCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int Id { get; set; }
    }
}
