
namespace DTO.Request.Report
{
    public class MemberOnMembersTable
    {
        public Guid? memberId { get; set; }
        public string badgeNumber { get; set; }
        public bool isDriver { get; set; }
        public bool isTransport { get; set; }
        public bool isSceneOnly { get; set; }
    }
}
