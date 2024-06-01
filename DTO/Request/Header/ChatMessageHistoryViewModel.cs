namespace DTO.Request.Header
{
    public class ChatMessageHistoryViewModel
    {
        public int ChatMessageHistoryId { get; set; }
        public string PhoneNumber { get; set; }
        public string UserId { get; set; }
        public string TextMessage { get; set; }
        public string MessageType { get; set; }
        public string MessageId { get; set; }
        public string Name { get; set; }
        public string BadgeNumber { get; set; }
        public string ContactId { get; set; }
        public string MemberId { get; set; }
        public string ExpertisesId { get; set; }
        public int? IsRead { get; set; }
        public int? UnRead { get; set; }
        public DateTime? MessageCreateOn { get; set; }
        public string CreatedBy { get; set; }
        public bool? IsMember { get; set; }
        public string ChatContactMemberId { get; set; }
        public int? clientId { get; set; }
    }
}
