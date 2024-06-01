namespace DTO.Response.Settings
{
    public class GetRadioChannelResponseDto
    {
        public int RadioChannelId { get; set; }
        public int? DefaultRadioId { get; set; }
        public int? NightDefaultRadioId { get; set; }
        public string StartTime { get; set; } = "00:00:00";
        public string EndTime { get; set; } = "06:00:00";
        public DateTime? UpdatedDate { get; set; }
    }
}
