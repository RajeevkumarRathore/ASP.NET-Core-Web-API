using DTO.Response;
using DTO.Response.Report;

namespace DTO.Request.ClientInfo
{
    public class CallDetailViewModel
    {
        public string callId { get; set; }
        public string fullName { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string phone { get; set; }
        public string type { get; set; }
        public string callType { get; set; }
        public string audio { get; set; }
        public string dispatcher { get; set; }
        public string CanceledCallOrDismissedEvents { get; set; }
        public decimal? latitude { get; set; }
        public decimal? longitude { get; set; }
        public string address { get; set; }
        public List<MembersResponseDto> respondedAgents { get; set; } = new List<MembersResponseDto>();
        public List<CallDetailActivityViewModel> activities { get; set; } = new List<CallDetailActivityViewModel>();
        public List<CallDetailNotesViewModel> notes { get; set; } = new List<CallDetailNotesViewModel>();
    }
}
