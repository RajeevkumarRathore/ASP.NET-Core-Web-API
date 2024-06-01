using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class ClientMembers :IEntity
    {
        [Key]
        public int Id { get; set; }

        public int ClientsId { get; set; }

        public Guid MembersId { get; set; }

        public bool MemberAccepted { get; set; }

        public bool DispatcherAccepted { get; set; }

        public bool IsVolunteer { get; set; }

        public bool SceneOnly { get; set; }

        public bool Driver { get; set; }

        public bool ApprovedByMember { get; set; }
        public bool IsFromApp { get; set; }
        public bool IsFromTextMessage { get; set; }
        public int? AssignedById { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public virtual Clients Clients { get; set; }

        public virtual Members Members { get; set; }
        public bool Transport { get; set; }
    }
}
