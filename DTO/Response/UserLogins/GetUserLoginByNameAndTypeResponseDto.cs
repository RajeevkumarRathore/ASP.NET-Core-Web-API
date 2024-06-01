namespace DTO.Response.UserLogins
{
    public class GetUserLoginByNameAndTypeResponseDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string LoginType { get; set; }
        public DateTime LoginDate { get; set; }
        public DateTime? LogoutDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
