using Application.Common.Dtos;

namespace Application.Common.Request
{
    public class CommonRequest
    {
        public int StartRow { get; set; }
        public int EndRow { get; set; }
        public string FilterQuery { get; set; }
        public string OrderBy { set; get; }
        public string SearchText { set; get; }
        public dynamic FilterModel { get; set; }
        public List<SortModel> SortModel { set; get; }
        public CommonRequest()
        {
            SortModel = new List<SortModel>();
        }
    }
}
