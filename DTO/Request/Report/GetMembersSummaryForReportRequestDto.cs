using DTO.Request.CallHistory;

namespace DTO.Request.Report
{
    public class GetMembersSummaryForReportRequestDto
    {
        public int year { get; set; }
        public bool isNSCoordinator { get; set; }
        public int? emergencyType { get; set; }
        public int StartRow { get; set; }
        public int EndRow { get; set; }
        public dynamic FilterModel { get; set; }
        public string OrderBy { set; get; }
        public string SearchText { set; get; }
        public List<SortModel> SortModel { set; get; }
        public GetMembersSummaryForReportRequestDto()
        {
            SortModel = new List<SortModel>();
        }
    }
}
