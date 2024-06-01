namespace DTO.Response.Dashboard
{
    public class GetOpenCompletedPcrByBadgeNumberResponseDto
    {
        public DateTime DateTime { get; set; }
        public string CadNumber { get; set; }
        public string BadgeNumber { get; set; }
        public string CallType { get; set; }
        public string Address { get; set; }
    }
}
