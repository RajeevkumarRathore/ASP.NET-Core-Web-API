
namespace DTO.Response.CallHistory
{
    public class GetMemberCallHistoryReportByBadgeResponseDto
    {
        public int id { get; set; }
        public string cadNumber { get; set; }
        public string address { get; set; }
        public DateTime createdDate { get; set; }
        public string units { get; set; }
        public string drivers { get; set; }
        public string medics { get; set; }
        public string callType { get; set; }
        public string hospital { get; set; }
        public string cancelDismissStatus { get; set; }
        public string locationName { get; set; }
    }
}
