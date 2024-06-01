namespace DTO.Request.StreetArea
{
    public class CreateUpdateStreetAreaRequestDto
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public string AreaName { get; set; }
        public string? CityName { get; set; }
        public string? Zip { get; set; }
        public string StreetNumber { get; set; }
    }
}
