
namespace DTO.Response.Report
{
    public class MemberReportSummaryResult
    {
        public List<MemberReportSummaryDto> members { get; set; }
        public List<MemberReportCountsDto> counts { get; set; }
        public List<ResExperties> expertisesList { get; set; }
    }
}
