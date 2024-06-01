
namespace DTO.Response.Report
{
    public class GetCallHistoryShabbosHourlyResponseDto
    {
        public List<GetCallHistoryMemberShabbosHourlyDto> members { get; set; }
        public List<MemberReportCountsDto> counts { get; set; }
        public List<ResExperties> expertisesList { get; set; }
    }
}
