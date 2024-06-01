
namespace DTO.Request.Hospitals
{
    public class CreateUpdateHospitalRequestDto
    {
        public int Id { get; set; }
        public string HospitalName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string FacilityType { get; set; }
        public string DispositionCode { get; set; }
        public string CityCode { get; set; }
        public string MainPhone { get; set; }
        public string ErPhone { get; set; }
        public string ErFax { get; set; }
        public string PedsErFax { get; set; }
        public string AltFax { get; set; }
        public string Ld { get; set; }
        public string Nickname { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public int? RowNumber { get; set; }
        public bool? IsTopUsed { get; set; }
    }
}
