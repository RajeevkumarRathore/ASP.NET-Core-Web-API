namespace Domain.Entities
{
    public class SysRoles : IEntity
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public int? CallHistoryPermissionHours { get; set; }

        public IEnumerable<Users> Users { get; set; }
    }
}
