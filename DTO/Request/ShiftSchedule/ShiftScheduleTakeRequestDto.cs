namespace DTO.Request.ShiftSchedule
{
    public class ShiftScheduleTakeRequestDto
    {
        public int ShiftScheduleId { get; set; }
        public DateTime ScheduleDate { get; set; }
        public Guid MembersId { get; set; }
        public int? CreatedBy { get; set; }
        public int? CustomId { get; set; }
    }
}