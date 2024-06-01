using Domain.Entities;

namespace DTO.Response.Member
{
    public class ResMemberPhones
    {
        public int Id { get; set; }
        public Guid MemberId { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public Members Member { get; set; }
        public string FirebaseToken { get; set; }
        public bool IsApplicationPermitted { get; set; }
        public bool IsNotificationsOn { get; set; }
        public bool IsPrimary { get; set; }
    }
}
