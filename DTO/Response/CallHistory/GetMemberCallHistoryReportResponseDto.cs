namespace DTO.Response.CallHistory
{
    public class GetMemberCallHistoryReportResponseDto
    {
        public int id { get; set; }
        public string cadNumber { get; set; }
        public string address { get; set; }
        public DateTime createdDate { get; set; }
        public Guid? memberId { get; set; }
        public string badgeNumber { get; set; }
        public string units { get; set; }
        public string drivers { get; set; }
        public string medics { get; set; }
        public string unitsSceneOnly { get; set; }
        public string buses { get; set; }
        public string allOtherMembers { get; set; }
        public string callType { get; set; }
    }
}
