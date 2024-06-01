namespace DTO.Response.Report
{
    public class MemberReportDto
    {
        public string badge_number { get; set; }
        public string isNSUnit { get; set; }
        public string memberFirstName { get; set; }
        public string memberLastName { get; set; }
        public int? driver { get; set; }
        public int? transport { get; set; }
        public int? noneTransport { get; set; }
        public int? toScene { get; set; }
        public int? nu { get; set; }
        public int? dayCalls { get; set; }
        public int? nightCalls { get; set; }
        public int? memberTotal { get; set; }
        public string date { get; set; }
        public string expertises { get; set; }
        public IEnumerable<ResExperties> expertisesList { get; set; }
        public string memberName { get; set; }
    }
}
