namespace DTO.Response.Member
{
    public class ResMemberPhoneInfo
    {
        public int id { get; set; }
        public string phone { get; set; }
        public bool isActive { get; set; }
        public bool isAppPermitted { get; set; }
        public bool isNotificationsOn { get; set; }
        public bool isPrimary { get; set; }
        public bool IsShabbos { get; set; }
        public Guid user_id { get; set; }
    }
}
