using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Command.UpdateIsNsUnit
{
    public class UpdateIsNsUnitCommand : IRequest<CommonResultResponseDto<string>>
    {
        public Guid user_id { get; set; }
        public bool isNsUnit { get; set; }
    }
}
