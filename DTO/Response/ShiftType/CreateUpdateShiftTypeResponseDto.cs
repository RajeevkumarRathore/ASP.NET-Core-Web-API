namespace DTO.Response.ShiftType
{
    public class CreateUpdateShiftTypeResponseDto
    {
        public int Id { get; set; }
        public string ShiftTypeName { get; set; }

        public int Status { get; set; }
        public string MemberType { get; set; }
        public virtual ICollection<ShiftScheduleTypeResponseDto> ShiftSchedules { get; set; }
    }
}
