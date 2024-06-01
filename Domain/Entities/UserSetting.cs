namespace Domain.Entities
{
    public class UserSetting :IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }

        public bool Status { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
