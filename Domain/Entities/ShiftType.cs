using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class ShiftType : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string ShiftTypeName { get; set; }
        public int Status { get; set; }
        public string MemberType { get; set; }
        public virtual ICollection<ShiftSchedule> ShiftSchedules { get; set; }
    }
}
