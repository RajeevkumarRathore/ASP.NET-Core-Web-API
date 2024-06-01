using Domain.Entities;

namespace DTO.Request.User
{
    public class RolePermissionsRequest
    {
        public int Id { get; set; }
        public int PermissionsId { get; set; }
        public int SysRolesId { get; set; }

        //Referencial
        public virtual Permissions Permissions { get; set; }
        public virtual SysRoles SysRoles { get; set; }
    }
}
