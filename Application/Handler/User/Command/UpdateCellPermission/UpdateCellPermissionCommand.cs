using DTO.Request.User;
using DTO.Response;
using MediatR;

namespace Application.Handler.User.Command.UpdateCellPermission
{
    public class UpdateCellPermissionCommand : IRequest<CommonResultResponseDto<UpdateCellPermissionRequestDto>>
    {
        public int SysRoleId { get; set; }
        public int PermissionId { get; set; }
        public int? ConfirmPermissionId { get; set; }
        public bool IsActive { get; set; }
        public bool IsMain { get; set; }
        public int? locationId { get; set; }
    }
}
