namespace DTO.Request.User
{
    public class UpdateCellPermissionRequestDto
    {
        public int SysRoleId { get; set; }
        public int PermissionId { get; set; }
        public int? ConfirmPermissionId { get; set; }
        public bool IsActive { get; set; }
        public bool IsMain { get; set; }
        public int? locationId { get; set; }
    }
}
