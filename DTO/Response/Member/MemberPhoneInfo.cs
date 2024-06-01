namespace DTO.Response.Member
{
    public class MemberPhoneInfo
    {
        public int id { get; set; }
        public string phone { get; set; }
        public bool isActive { get; set; }
        public bool isAppPermitted { get; set; }
        public bool isNotificationsOn { get; set; }
        public bool isPrimary { get; set; }
    }
}
