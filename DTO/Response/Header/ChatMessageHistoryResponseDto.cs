namespace DTO.Response.Header
{
    public class ChatMessageHistoryResponseDto
    {
        public int ChatMessageHistoryId { get; set; }
        public string PhoneNumber { get; set; }
        public string TextMessage { get; set; }
        public string MessageType { get; set; }
        public DateTime? MessageCreateOn { get; set; }
        public string CreatedBy { get; set; }
        public int? ClientId { get; set; }
    }
}
