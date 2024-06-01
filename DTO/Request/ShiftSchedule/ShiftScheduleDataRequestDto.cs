namespace DTO.Request.ShiftSchedule
{
    public class ShiftScheduleDataRequestDto
    {
        public DateTime scheduleDate { get; set; }
        public int selectedShiftTime { get; set; }
        public string selectedMember { get; set; }
        public Guid selectedMemberId { get; set; }
        public bool? isWeekly { get; set; }
        public DateTime? endDate { get; set; }
        public bool? isBiweekly { get; set; }
        public bool? isEvery3Weeks { get; set; }
        public bool? isEvery4Weeks { get; set; }
        public bool? isEvery5Weeks { get; set; }
        public bool? isEvery6Weeks { get; set; }
        public bool? isEvery7Weeks { get; set; }
        public bool? isEvery8Weeks { get; set; }
        public int? loggedInUserId { get; set; }
        public int? customId { get; set; }
        public bool? isCustom { get; set; }
    }
}
