using DTO.Response.User;
using DTO.Response;
using MediatR;
namespace Application.Handler.User.Queries.GetAllRolesAlongWithUsersActiveRoleAndPermissions
{
    public class GetRolesPermissionByRoleIdQuery : IRequest<CommonResultResponseDto<IList<RolePermissionResponseDto>>>
    {
        public int RoleId { get; set; }
    }
}
