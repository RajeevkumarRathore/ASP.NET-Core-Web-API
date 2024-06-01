namespace DTO.Response.ShiftType
{
    public class ShiftSchedulePlanResponseDto
    {
        public int Id { get; set; }
        public virtual ShiftSchedulePlanResponseDto ShiftSchedule { get; set; }
        public int ShiftScheduleId { get; set; }
        public int DayOfWeek { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
