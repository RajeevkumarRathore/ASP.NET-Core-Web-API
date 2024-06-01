namespace DTO.Request.ShiftSchedule
{
    public class EditShiftScheduleRequestDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public int shiftTypeId { get; set; }
    }
}
