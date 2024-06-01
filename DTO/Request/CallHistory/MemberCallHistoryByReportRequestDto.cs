namespace DTO.Request.CallHistory
{
    public class MemberCallHistoryByReportRequestDto
    {
        public string badgeNumber { get; set; }
        public string fromTime { get; set; }
        public string toTime { get; set; }
        public bool isMember { get; set; }
        public bool isShabbos { get; set; }
        public string hour { get; set; }
    }
}
