using DTO.Response;
using DTO.Response.User;
using MediatR;

namespace Application.Handler.User.Command.UpdateRolePermission
{
    public class UpdateRolePermissionCommand : IRequest<CommonResultResponseDto<UpdateRolePermissionResponseDto>>
    {
        public int SysRoleId { get; set; }
        public int ViewPermissionId { get; set; }
        public int EditPermissionId { get; set; }
        public bool IsActive { get; set; }
        public string PermissionType { get; set; }
    }
}
