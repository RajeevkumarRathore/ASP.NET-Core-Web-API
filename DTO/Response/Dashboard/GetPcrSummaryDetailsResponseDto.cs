namespace DTO.Response.Dashboard
{
    public class GetPcrSummaryDetailsResponseDto
    {
        public string Member { get; set; }
        public int OpenPcr { get; set; }
        public int CompletedPcr { get; set; }
        public int ApprovedPcr { get; set; }
    }
}
