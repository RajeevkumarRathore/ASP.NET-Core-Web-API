namespace Domain.Entities
{
    public class DispatcherLogin : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool IsDispatcher { get; set; }
        public DateTime? DispatchingFromTime { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
