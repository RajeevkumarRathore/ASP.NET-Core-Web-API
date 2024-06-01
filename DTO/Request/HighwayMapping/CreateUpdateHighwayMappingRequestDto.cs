

namespace DTO.Request.HighwayMapping
{
    public class CreateUpdateHighwayMappingRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public bool IsMilemark { get; set; }
        public bool IsExit { get; set; }
        public string RelatedHighway { get; set; }
    }
}
