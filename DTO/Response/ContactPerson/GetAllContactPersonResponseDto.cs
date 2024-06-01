namespace DTO.Response.ContactPerson
{
    public class GetAllContactPersonResponseDto
    {
        public int Id { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonLastname { get; set; }
        public string ContactPersonPhone { get; set; }
        public string ContactPersonStreet { get; set; }
        public string ContactPersonApartment { get; set; }
        public string ContactPersonNote { get; set; }
    }
}
