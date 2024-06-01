using DTO.Request.CallHistory;

namespace DTO.Request.Report
{
    public class GetMembersReportByDateRangeRequestDto
    {
        public string fromTime { get; set; }
        public string toTime { get; set; }
        public string dayFromTime { get; set; }
        public string dayToTime { get; set; }
        public string nightFromTime { get; set; }
        public string nightToTime { get; set; }
        public bool byDate { get; set; }
        public bool isNSCoordinator { get; set; }
        public int? emergencyType { get; set; }
        public int StartRow { get; set; }
        public int EndRow { get; set; }
        public dynamic FilterModel { get; set; }
        public string OrderBy { set; get; }
        public string SearchText { set; get; }
        public List<SortModel> SortModel { set; get; }
        public GetMembersReportByDateRangeRequestDto()
        {
            SortModel = new List<SortModel>();
        }
    }
}
