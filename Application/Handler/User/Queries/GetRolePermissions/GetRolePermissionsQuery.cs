
using DTO.Response;
using DTO.Response.User;
using MediatR;

namespace Application.Handler.User.Queries.GetRolePermissions
{
    public class GetRolePermissionsQuery : IRequest<CommonResultResponseDto<IList<RolePermissionResponseDto>>>
    {
        public int UserId { get; set; }
        public int SysRoleId { get; set; }
    }
}
