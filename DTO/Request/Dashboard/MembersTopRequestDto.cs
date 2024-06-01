namespace DTO.Request.Dashboard
{
    public class MembersTopRequestDto
    {
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string? DayCallFromtime { get; set; }
        public string? DayCallTotime { get; set; }
        public string? NightCallFromtime { get; set; }
        public string? NightCallTotime { get; set; }
        public string? JsonProperties { get; set; }
    }
}
