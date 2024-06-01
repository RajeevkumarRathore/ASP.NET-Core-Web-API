namespace DTO.Response.ShiftSchedules
{
    public class ShiftSchedulePlansByShiftTypeResponseDto
    {
        public int id { get; set; }
        public int shiftScheduleId { get; set; }
        public int isActive { get; set; }
        public int status { get; set; }
        public int dayOfWeek { get; set; }
        public int shiftTypeId { get; set; }
        public string description { get; set; }
        public DateTime? createdDate { get; set; }
        public DateTime? updatedDate { get; set; }
    }
}
