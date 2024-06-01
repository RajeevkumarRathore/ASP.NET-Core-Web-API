namespace DTO.Request.User
{
    public class UpdateRolePermissionRequestDto
    {
        public int SysRoleId { get; set; }
        public int ViewPermissionId { get; set; }
        public int EditPermissionId { get; set; }
        public bool IsActive { get; set; }
        public string PermissionType { get; set; }
    }
}
