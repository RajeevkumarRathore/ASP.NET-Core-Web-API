namespace DTO.Request.CallHistory
{
    public class MemberCallHistoryReportByBadgeRequestDto
    {
        public string badgeNumber { get; set; }
        public DateTime fromTime { get; set; }
        public DateTime toTime { get; set; }
    }
}
