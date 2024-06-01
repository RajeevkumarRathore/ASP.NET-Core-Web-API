namespace DTO.Request.Settings
{
    public class UpdateCanListenToOpenPhoneCallsTimeSettingsRequestDto
    {
        public string FromTime { get; set; } = "00:00:00";
        public string ToTime { get; set; } = "07:00:00";
    }
}
