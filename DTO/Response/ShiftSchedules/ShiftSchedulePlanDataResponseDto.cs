namespace DTO.Response.ShiftSchedules
{
    public class ShiftSchedulePlanDataResponseDto
    {
        public int shiftScheduleId { get; set; }
        public string shiftScheduleName { get; set; }
        public int shiftTypeId { get; set; }
        public int? shiftSchedulePlanId { get; set; }
        public int? dayOfWeek { get; set; }
        public string dayOfWeekName { get; set; }
        public int? shiftSchedulePlanStatus { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
    }
}
