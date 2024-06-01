namespace DTO.Request.CallHistory
{
    public class GetCallHistoryViewModelRequestDto
    {
        public int ContactId { get; set; }
        public int? clientId { get; set; }
        public string callerNumber { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public int? currentLoggedInUser { get; set; }
        public bool? fromCallHistoryTab { get; set; }
        public bool isDispatchedCallsOnly { get; set; }
        public DateTime DateParameterAccordingToUser { get; set; }
        public int StartRow { get; set; }
        public int EndRow { get; set; }
        public dynamic FilterModel { get; set; }
        public string OrderBy { set; get; }
        public string SearchText { set; get; }
        public List<SortModel> SortModel { set; get; }
        public string UserName { get; set; }
        public int? UserRoleID { get; set; }
        public GetCallHistoryViewModelRequestDto()
        {
            SortModel = new List<SortModel>();
        }
        public bool IsALSActivatedCallsOnly { get; set; }
    }
}
