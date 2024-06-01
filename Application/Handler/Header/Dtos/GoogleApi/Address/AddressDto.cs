namespace Application.Handler.Header.Dtos.GoogleApi.Address
{
    public class PeopleInfoCard
    {
        public PeopleNameCard PeopleNameCard { get; set; }
        public PeopleAddressCard PeopleAddressCard { get; set; }
        public PeopleInformationCard PeopleInformationCard { get; set; }
        public PeopleGenderCard PeopleGenderCard { get; set; }
        public PeopleLocationCard PeopleLocationCard { get; set; }
    }

    public class PeopleNameCard
    {
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HebrewName { get; set; }
        public string ParentName { get; set; }
    }

    public class PeopleInformationCard
    {
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Other1 { get; set; }
        public string Other2 { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
    }

    public class PeopleGenderCard
    {
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Birthdate { get; set; }
    }

    public class PeopleAddressCard
    {
        public string FullAddress { get; set; }
        public string OriginalAddress { get; set; }
        public string FormattedAddress { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Township { get; set; }
        public string Cross { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string Room { get; set; }
        public string Floor { get; set; }
        public string Apt { get; set; }
        public string GoogleCross { get; set; }
        public string GoogleStreet { get; set; }
        public string GoogleApt { get; set; }
        public List<AddressComponent> address_components { get; set; }
        public string StateShortName { get; set; }
        public string resultGeoType { get; set; }
        public string placeId { get; set; }
    }

    public class PeopleLocationCard
    {
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
