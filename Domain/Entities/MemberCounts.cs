using System.ComponentModel.DataAnnotations;
namespace Domain.Entities
{
    public class MemberCounts
    {
        [Key]
        public int total_member { get; set; }
        public int units { get; set; }
        public int medics { get; set; }
        public int drivers { get; set; }
        public int other { get; set; }
        public int buses { get; set; }
        public int als { get; set; }
    }
}
