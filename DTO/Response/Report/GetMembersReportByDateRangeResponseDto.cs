namespace DTO.Response.Report
{
    public class GetMembersReportByDateRangeResponseDto
    {
        public List<MemberReportDto> members { get; set; }
        public List<MemberReportCountsDto> counts { get; set; }
        public List<ResExperties> expertisesList { get; set; }
    }
}
