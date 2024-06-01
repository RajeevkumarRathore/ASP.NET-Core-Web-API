
using Domain.Entities;

namespace DTO.Response.ShiftSchedules
{
    public class ShiftTypesResponseDto
    {
        public int Id { get; set; }
        public string ShiftTypeName { get; set; }
        public int Status { get; set; }
        public string MemberType { get; set; }
        public virtual ICollection<ShiftSchedule> ShiftSchedules { get; set; }
    }
}
