using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class MemberPhones :IEntity
    {
        [Key]
        public int Id { get; set; }
        public Guid MemberId { get; set; }
        [MaxLength(50)]
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        [JsonIgnore]
        public Members Member { get; set; }
        [JsonIgnore]
        [MaxLength(250)]
        public string FirebaseToken { get; set; }
        public bool IsApplicationPermitted { get; set; }
        public bool IsNotificationsOn { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsShabbos { get; set; }
    }
}
