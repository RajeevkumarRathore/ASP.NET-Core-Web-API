namespace DTO.Response.User
{
    public class RolePermissionResponseDto
    {
        //public int SysRoleId { get; set; }
        //public int PermissionId { get; set; }
        //public string Name { get; set; }
        public string DisplayName { get; set; }
        //public string NormalizedName { get; set; }
        //public bool IsActive { get; set; }
        //public bool IsOtherPermission { get; set; }
        public int ViewId { get; set; }
        public int EditId { get; set; }
        public bool IsView { get; set; }
        public bool IsEdit { get; set; }
        public bool IsOtherView { get; set; }
        public bool IsOtherEdit { get; set; }
        public bool IsActiveView { get; set; }
        public bool IsActiveEdit { get; set; }
        public int CallHistoryPermissionHours { get; set; }
    }
}
