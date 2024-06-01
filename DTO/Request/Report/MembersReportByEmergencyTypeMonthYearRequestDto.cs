using DTO.Request.CallHistory;

namespace DTO.Request.Report
{
    public class MembersReportByEmergencyTypeMonthYearRequestDto
    {
        public int month { get; set; }
        public int year { get; set; }
        public int? emergencyType { get; set; }
        public int StartRow { get; set; }
        public int EndRow { get; set; }
        public dynamic FilterModel { get; set; }
        public string OrderBy { set; get; }
        public string SearchText { set; get; }
        public List<SortModel> SortModel { set; get; }
        public MembersReportByEmergencyTypeMonthYearRequestDto()
        {
            SortModel = new List<SortModel>();
        }
    }
}
