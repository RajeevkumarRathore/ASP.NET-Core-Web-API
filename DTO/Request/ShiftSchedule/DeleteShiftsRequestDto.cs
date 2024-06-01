namespace DTO.Request.ShiftSchedule
{
    public class DeleteShiftsRequestDto
    {
        public int shiftScheduleTakeId { get; set; }
        public int? dayOfWeek { get; set; }
        public int loggedInUserId { get; set; }
        public int selectedDeleteType { get; set; }
    }
}
