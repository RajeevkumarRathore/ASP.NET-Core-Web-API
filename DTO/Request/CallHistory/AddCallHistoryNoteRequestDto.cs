namespace DTO.Request.CallHistory
{
    public class AddCallHistoryNoteRequestDto
    {
        public int clientId { get; set; }
        public string note { get; set; }
        public string createdBy { get; set; }
        public DateTime createdDate { get; set; }
    }
}
