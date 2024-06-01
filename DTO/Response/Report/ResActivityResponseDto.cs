using Domain.Entities;
using DTO.Request.Report;

namespace DTO.Response.Report
{
    public class ResActivityResponseDto
    {
        public List<GetCallHistoryDetailResponseDto> activityResponse { get; set; }
        public List<StatusInfo> dismissedEventOptions { get; set; }
        public List<MemberOnMembersTable> members { get; set; }
        public List<Hospital> hospitalOptions { get; set; }
    }
}
