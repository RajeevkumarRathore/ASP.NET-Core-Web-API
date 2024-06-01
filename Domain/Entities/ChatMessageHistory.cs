namespace Domain.Entities
{
    public class ChatMessageHistory: IEntity
    {
        public int ChatMessageHistoryId { get; set; }
        public string PhoneNumber { get; set; }
        public string TextMessage { get; set; }
        public string MessageType { get; set; }
        public string MessageId { get; set; }
        public string ContactId { get; set; }
        public string MemberId { get; set; }
        public bool IsRead { get; set; }
        public DateTime MessageCreateOn { get; set; }
        public string CreatedBy { get; set; }
        public int? ClientId { get; set; }
        public int? TextMessageMemberAdditionsId { get; set; }
    }
}
