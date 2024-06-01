

namespace DTO.Response.Areas
{
    public class GetAllAreasResponseDto
    {
        public int Id { get; set; }
        public string AreaName { get; set; }
        public string ZipCode { get; set; }
        public string CityName { get; set; }
        public bool FireDistrict { get; set; }
    }
}
