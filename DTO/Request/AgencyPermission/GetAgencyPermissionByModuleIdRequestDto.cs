using DTO.Request.CallHistory;

namespace DTO.Request.AgencyPermission
{
        public class GetAgencyPermissionByModuleIdRequestDto
        {
            public int AgencyModuleId { get; set; }
            public int StartRow { get; set; }
            public int EndRow { get; set; }
            public dynamic FilterModel { get; set; }
            public string OrderBy { set; get; }
            public string SearchText { set; get; }
            public List<SortModel> SortModel { set; get; }
            public GetAgencyPermissionByModuleIdRequestDto()
            {
                SortModel = new List<SortModel>();
            }
        }
    
}
