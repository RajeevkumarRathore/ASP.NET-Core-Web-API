
namespace DTO.Request.ClientInfo
{
    public class CallHistoryRequestDto
    {
        public string quickFilter { get; set; }

        public int? contactId { get; set; }
        public int? clientId { get; set; }
        public string callerNumber { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public int? currentLoggedInUser { get; set; }
        public bool? fromCallHistoryTab { get; set; }
        public bool isDispatchedCallsOnly { get; set; }
    }
}

