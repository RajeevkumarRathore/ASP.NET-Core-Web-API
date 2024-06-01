namespace DTO.Response.Settings
{
    public class AddressHostResponseDto
    {
        public int HouseNumber { get; set; }
        public object HouseSuffix { get; set; }
        public object PreDirectional { get; set; }
        public string StreetName { get; set; }
        public string StreetSuffix { get; set; }
        public object PostDirectional { get; set; }
        public object AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public int Zip { get; set; }
        public object PlusFour { get; set; }
        public object County { get; set; }
        public string Country { get; set; }
        public string AddressType { get; set; }
    }
}
