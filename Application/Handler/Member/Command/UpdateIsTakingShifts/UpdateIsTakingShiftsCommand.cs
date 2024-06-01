using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Command.UpdateIsTakingShifts
{
    public class UpdateIsTakingShiftsCommand : IRequest<CommonResultResponseDto<string>>
    {
        public Guid user_id { get; set; }
        public bool isTakingShifts { get; set; }
    }
}
