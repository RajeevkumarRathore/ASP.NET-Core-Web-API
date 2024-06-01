namespace Domain.Entities
{
    public class HelpUser : IEntity
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string BadgeNumber { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Whatsapp { get; set; }
        public string Telegram { get; set; }
        public string createdBy { get; set; }
        public string updatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
