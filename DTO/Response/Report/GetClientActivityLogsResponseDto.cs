namespace DTO.Response.Report
{
    public class GetClientActivityLogsResponseDto
    {
        public int id { get; set; }
        public int clientId { get; set; }
        public string activity { get; set; }
        public DateTime createdDate { get; set; }
    }
}
