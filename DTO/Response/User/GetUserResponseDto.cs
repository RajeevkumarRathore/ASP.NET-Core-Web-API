namespace DTO.Response.User
{
    public class GetUserResponseDto
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fullName { get; set; }
        public string eMail { get; set; }
        public string lastLogin { get; set; }
        public string status { get; set; }
        public string phoneNumber { get; set; }
        public string role { get; set; }
        public int roleId { get; set; }
        public bool thankYouMessagePermission { get; set; }
    }
}
