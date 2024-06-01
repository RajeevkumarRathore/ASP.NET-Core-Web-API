using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Calls : IEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(10)]
        public string Line { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string Number { get; set; }

        public bool Deleted { get; set; }
        public string UniqueCallId { get; set; }

        //[JsonIgnore]
        public DateTime? CreatedDate { get; set; }

        //[JsonIgnore]
        public DateTime? UpdatedDate { get; set; }
        [NotMapped]
        public string username { get; set; }
    }
}
