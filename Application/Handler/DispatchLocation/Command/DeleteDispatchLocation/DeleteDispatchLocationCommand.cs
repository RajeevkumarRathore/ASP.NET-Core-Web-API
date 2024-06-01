using DTO.Response;
using MediatR;

namespace Application.Handler.DispatchLocation.Command.DeleteDispatchLocation
{
    public class DeleteDispatchLocationCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int Id { get; set; }
    }
}
