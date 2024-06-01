
using DTO.Request.ClientInfo;
using DTO.Response.Report;

namespace DTO.Response.CallHistory
{
    public class GetCallHistoryShabbosResponseDto
    {
        public List<CallHistoryViewModel> members { get; set; }
        public List<MemberReportCountsDto> counts { get; set; }
        public List<ResExperties> expertisesList { get; set; }
    }
}