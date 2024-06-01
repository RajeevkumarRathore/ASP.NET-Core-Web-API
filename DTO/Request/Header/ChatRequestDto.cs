namespace DTO.Request.Header
{
    public class ChatRequestDto
    {
        public string ChatContactMemberId { get; set; }
        public string CreatedBy { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsMember { get; set; }
        public string TextMessage { get; set; }
    }
}
