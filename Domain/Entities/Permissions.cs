namespace Domain.Entities
{
    public class Permissions : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool IsMenu { get; set; }
        public bool IsOtherPermission { get; set; } 
    }
}
