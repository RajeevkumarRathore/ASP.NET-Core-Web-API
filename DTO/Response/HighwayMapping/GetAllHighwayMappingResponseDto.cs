
namespace DTO.Response.HighwayMapping
{
    public class GetAllHighwayMappingResponseDto
    {
        public int Id { get; set; }
        public string HighwayMappingName { get; set; }
        public decimal HighwayMappingLatitude { get; set; }
        public decimal HighwayMappingLongitude { get; set; }
        public bool HighwayMappingIsMilemark { get; set; }
        public bool HighwayMappingIsExit { get; set; }
        public string RelatedHighwayName { get; set; }
    }
}
