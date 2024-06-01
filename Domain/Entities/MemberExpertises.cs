using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class MemberExpertises : IEntity
    {
        [Key]
        public int Id { get; set; }

        public Guid Membersuser_id { get; set; }

        public int ExpertisesId { get; set; }

        public virtual Members Members { get; set; }

        public virtual Expertises Expertises { get; set; }
    }
}
