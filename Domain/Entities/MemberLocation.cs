using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class MemberLocation :IEntity
    {
        [Key]
        public int Id { get; set; }
        public Guid Membersuser_id { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public decimal heading { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Members Members { get; set; }
    }
}
