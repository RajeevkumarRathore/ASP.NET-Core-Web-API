namespace DTO.Request.Report
{
    public class NightCallTimesSettingsRequestDto
    {
        public string dayCallFromtime { get; set; }

        public string dayCallTotime { get; set; }

        public string nightCallFromtime { get; set; }

        public string nightCallTotime { get; set; }

        public bool isEnabled { get; set; }
    }
}
