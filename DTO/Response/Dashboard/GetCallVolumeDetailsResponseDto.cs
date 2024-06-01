namespace DTO.Response.Dashboard
{
    public class GetCallVolumeDetailsResponseDto
    {
        public DateTime TargetDate { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public int CallVolume { get; set; }


    }
}
