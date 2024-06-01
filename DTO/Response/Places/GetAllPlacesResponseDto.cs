namespace DTO.Response.Places
{
    public class GetAllPlacesResponseDto
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
        public string FullAddress { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Township { get; set; }
        public string Cross { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string Apartment { get; set; }
        public string Room { get; set; }
        public string Floor { get; set; }
        public string EntryCode { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string GoogleApt { get; set; }
        public string GoogleCross { get; set; }
        public string GoogleStreet { get; set; }
        public bool? IsHwy { get; set; }
        public string PhoneNumber { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
