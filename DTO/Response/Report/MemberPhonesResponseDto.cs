namespace DTO.Response.Report
{
    public class MemberPhonesResponseDto
    {
        public int Id { get; set; }
        public Guid? MemberId { get; set; }
        public string Phone { get; set; }
        public bool? IsActive { get; set; }
        public string FirebaseToken { get; set; }
        public bool? IsApplicationPermitted { get; set; }
        public bool? IsNotificationsOn { get; set; }
        public bool? isPrimary { get; set; }
    }
}
