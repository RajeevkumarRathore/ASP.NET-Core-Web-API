namespace DTO.Request.Report
{
    public class GetNightCallTimesSettingsRequestDto
    {
        public string dayCallFromtime { get; set; }

        public string dayCallTotime { get; set; }

        public string nightCallFromtime { get; set; }

        public string nightCallTotime { get; set; }

        public bool isEnabled { get; set; }

        public string JsonProperties { get; set; }
    }
}
