using DTO.Response;
using MediatR;

namespace Application.Handler.User.Command.UpdateUserRole
{
    public class UpdateUserRoleCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int UserId { get; set; }
        public int SysRoleId { get; set; }
    }
}
