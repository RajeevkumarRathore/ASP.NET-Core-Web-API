namespace DTO.Response.StreetArea
{
    public class CreateUpdateStreetAreaResponseDto
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public string AreaName { get; set; }
        public string CityName { get; set; }
        public int? StreetAreaZip { get; set; }
        public string StreetNumber { get; set; }
    }
}
