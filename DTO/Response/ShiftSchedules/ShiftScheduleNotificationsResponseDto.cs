namespace DTO.Response.ShiftSchedules
{
    public class ShiftScheduleNotificationsResponseDto
    {
        public int shiftScheduleId { get; set; }
        public string phoneNumber { get; set; }
        public string textMessage { get; set; }
        public string memberFirstName { get; set; }
        public string memberLastName { get; set; }
        public Guid? memberId { get; set; }
    }
}
