namespace DTO.Request.Settings
{
    public class UpdateHostSettingRequestDto
    {
        public string Host1 { get; set; }
        public int Port1 { get; set; }
        public string Host2 { get; set; }
        public int Port2 { get; set; }
        public string FinalDestination { get; set; }
        public bool? SwitchHosts { get; set; }
    }
}
