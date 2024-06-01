namespace Domain.Entities
{
    public class TextMessageMemberAddition
    {
        public int Id { get; set; }
        public int ForBus { get; set; }
        public int ForScene { get; set; }
        public int? ClientId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
