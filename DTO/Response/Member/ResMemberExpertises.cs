
using Domain.Entities;

namespace DTO.Response.Member
{
    public class ResMemberExpertises
    {
        public int Id { get; set; }
        public Guid Membersuser_id { get; set; }
        public int ExpertisesId { get; set; }
        public virtual Members Members { get; set; }
        public virtual Expertises Expertises { get; set; }
    }
}
