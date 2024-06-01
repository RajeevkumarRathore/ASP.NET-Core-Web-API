namespace DTO.Response.HighwayMapping
{
    public class CreateUpdateHighwayMappingResponseDto
    {
        public int Id { get; set; }
     
        public string Name { get; set; }
    
        public decimal Latitude { get; set; }
       
        public decimal Longitude { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
      
        public string CreatedBy { get; set; }
        
        public string UpdatedBy { get; set; }
        public bool IsMileMark { get; set; }
        public bool IsExit { get; set; }
       
        public string RelatedHighway { get; set; }
    }
}
