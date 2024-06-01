using DTO.Response;
using MediatR;

namespace Application.Handler.DispatchLocation.Command.UpdateIsBayStatus
{
    public class UpdateIsBayStatusCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int Id { get; set; }
        public bool IsBay { get; set; }
    }
}
