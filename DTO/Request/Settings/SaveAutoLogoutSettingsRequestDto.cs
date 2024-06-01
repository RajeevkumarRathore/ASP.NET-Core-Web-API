namespace DTO.Request.Settings
{
    public class SaveAutoLogoutSettingsRequestDto
    {
        public bool EnableAutoLogout { get; set; }
        public bool AutoLogoutOnShabbos { get; set; }
        public int AutoLogoutTime { get; set; }
        public int CountdownTime { get; set; }
    }
}
