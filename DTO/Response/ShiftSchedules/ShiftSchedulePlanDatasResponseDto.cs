namespace DTO.Response.ShiftSchedules
{
    public class ShiftSchedulePlanDatasResponseDto
    {
        public int shiftScheduleId { get; set; }
        public string shiftScheduleName { get; set; }
        public int shiftTypeId { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public List<ShiftSchedulePlanResponseDto> shiftSchedulePlans { get; set; }
    }
}
