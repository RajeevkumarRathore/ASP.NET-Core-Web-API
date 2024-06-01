namespace DTO.Response.ShiftType
{
    public class ShiftScheduleTypeResponseDto
    {
        public int Id { get; set; }
        public string ScheduleName { get; set; }
        public virtual ShiftScheduleTypeResponseDto ShiftType { get; set; }

        public int ShiftTypeId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Description { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int Status { get; set; }
        public virtual ICollection<ShiftScheduleTakeResponseDto> ShiftScheduleTake { get; set; }
        public virtual ICollection<ShiftSchedulePlanResponseDto> ShiftSchedulePlan { get; set; }
    }
}
