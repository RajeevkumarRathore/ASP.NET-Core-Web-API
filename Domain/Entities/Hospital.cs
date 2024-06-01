namespace Domain.Entities
{
    public class Hospital :IEntity
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }            
            public string City { get; set; }            
            public string State { get; set; }            
            public string Zip { get; set; }
            public decimal? Latitude { get; set; }
            public decimal? Longitude { get; set; }
            public string FacilityType { get; set; }           
            public string DispositionCode { get; set; }            
            public string CityCode { get; set; }            
            public string MainPhone { get; set; }            
            public string ERPhone { get; set; }            
            public string ERFax { get; set; }            
            public string PedsERFax { get; set; }            
            public string AltFax { get; set; }            
            public string LD { get; set; }            
            public DateTime? CreatedDate { get; set; }            
            public DateTime? UpdatedDate { get; set; }
            public virtual ICollection<Clients> Clients { get; set; }            
            public string Nickname { get; set; }
            public int? RowNumber { get; set; }
            public bool IsDeleted { get; set; }        
    }
}
