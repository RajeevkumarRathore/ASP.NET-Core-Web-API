namespace DTO.Response.Header
{
    public class ChatHistoryViewModel
    {
        public string PhoneNumber { get; set; }
        public string ContactId { get; set; }
        public string MemberId { get; set; }
        public string ChatContactMemberId { get; set; }
        public string ExpertisesId { get; set; }
        public string UserId { get; set; }
        public string AgencyId { get; set; }
        public string TextMessage { get; set; }
        public DateTime? MessageCreateOn { get; set; }
        public string Name { get; set; }
        public string IsMember { get; set; }
        public string BadgeNumber { get; set; }
        public int? ReadCount { get; set; }
        public int? UnReadCount { get; set; }
        public string Status { get; set; }
    }
}
