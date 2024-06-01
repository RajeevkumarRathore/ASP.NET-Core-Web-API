namespace DTO.Response.Report
{
    public class GetCallHistoryNotesResponseDto
    {
        public int id { get; set; }
        public int clientId { get; set; }
        public string note { get; set; }
        public string createdBy { get; set; }
        public DateTime createdDate { get; set; }
    }
}
