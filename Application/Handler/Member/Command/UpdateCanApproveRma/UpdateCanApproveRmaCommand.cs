using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Command.UpdateCanApproveRma
{
    public class UpdateCanApproveRmaCommand : IRequest<CommonResultResponseDto<string>>
    {
        public Guid user_id { get; set; }
        public bool canApproveRma { get; set; }
    }
}
