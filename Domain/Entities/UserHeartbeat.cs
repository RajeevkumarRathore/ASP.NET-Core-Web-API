namespace Domain.Entities
{
    public class UserHeartbeat : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public DateTime HeartbeatTime { get; set; }
        public DateTime? LogoutTime { get; set; }
    }
}
