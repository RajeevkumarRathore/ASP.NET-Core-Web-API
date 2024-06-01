using DTO.Response;
using MediatR;

namespace Application.Handler.Areas.Command.DeleteAreas
{
    public class DeleteAreasCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int Id { get; set; }
    }
}
