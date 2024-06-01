namespace Domain.Entities
{
    public class Users : IEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public bool Isadmin { get; set; }
        public int? SysRolesId { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string Profile_pic { get; set; }
        public string Request_type { get; set; }
        public int? Status { get; set; }
        public int? OtpCode { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public DateTime? LastLogin { get; set; }
        public virtual SysRoles SysRoles { get; set; }
    }
}
