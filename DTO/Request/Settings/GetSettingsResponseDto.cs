namespace DTO.Request.Settings
{
    public class GetSettingsResponseDto
    {
        public int Id { get; set; }
        public string SettingName { get; set; }
        public string JsonProperties { get; set; }
    }
}
