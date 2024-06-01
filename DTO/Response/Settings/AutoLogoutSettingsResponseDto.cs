namespace DTO.Response.Settings
{
    public class AutoLogoutSettingsResponseDto
    {
        public bool EnableAutoLogout { get; set; }
        public bool AutoLogoutOnShabbos { get; set; }
        public int AutoLogoutTime { get; set; }
        public int CountdownTime { get; set; }
    }
}
