using DTO.Request.CallHistory;

namespace DTO.Request.Report
{
    public class GetCallHistoryShabbosHourlyRequestDto
    {
        public GetCallHistoryShabbosHourlyRequestDto()
        {
            SortModel = new List<SortModel>();
        }
        public string fromTime { get; set; }
        public string toTime { get; set; }
        public bool IsShabbosOnly { get; set; }
        public int StartRow { get; set; }
        public int EndRow { get; set; }
        public dynamic FilterModel { get; set; }
        public string OrderBy { set; get; }
        public string SearchText { set; get; }
        public List<SortModel> SortModel { set; get; }
       
    }
}
