using Domain.Entities;

namespace DTO.Response.ClientInfo
{
    public class RolePermissionsResponseDto
    {
        public int SysRolesId { get; set; }
        public int PermissionsID { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}
