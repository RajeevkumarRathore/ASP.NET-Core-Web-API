namespace DTO.Request.ShiftSchedule
{
    public class CreateShiftScheduleRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int ShiftTypeId { get; set; }
    }
}
