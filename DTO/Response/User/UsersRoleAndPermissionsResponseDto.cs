namespace DTO.Response.User
{
    public class UsersRoleAndPermissionsResponseDto
    {

        public int UserId { get; set; }

        public int SysRoleId { get; set; }

        public string Role { get; set; }

        public bool IsUsersCurrentRole { get; set; }
        public int? selectedRoleId { get; set; }

        public IEnumerable<RolePermissionResponseDto> RolePermissions { get; set; }

        public IEnumerable<IGrouping<string, RolePermissionResponseDto>> GroupedRolePermissions { get; set; }
        public int? callHistoryPermissionHours { get; set; }
    }
}
