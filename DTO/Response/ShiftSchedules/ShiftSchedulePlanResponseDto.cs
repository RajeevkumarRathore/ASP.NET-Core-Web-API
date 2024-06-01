namespace DTO.Response.ShiftSchedules
{
    public class ShiftSchedulePlanResponseDto
    {
        public int? shiftSchedulePlanId { get; set; }
        public int? dayOfWeek { get; set; }
        public string dayOfWeekName { get; set; }
        public int? shiftSchedulePlanStatus { get; set; }
    }
}
