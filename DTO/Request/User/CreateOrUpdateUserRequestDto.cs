namespace DTO.Request.User
{
    public class CreateOrUpdateUserRequestDto
    {
        public int? Id { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int SysRolesId { get; set; }
        public int Status { get; set; }
    }
}
