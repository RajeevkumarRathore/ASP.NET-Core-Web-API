
namespace Domain.Entities
{
    public class RolePermissions : IEntity
    {
        public int Id { get; set; }
        public int PermissionsId { get; set; }
        public int SysRolesId { get; set; }

        //Referencial
        public virtual Permissions Permissions { get; set; }
        public virtual SysRoles SysRoles { get; set; }
    }
}
