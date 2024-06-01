
namespace DTO.Response.ShiftSchedules
{
    public class ShiftScheduleTakeDataResponseDto
    {
        public int shiftTypeId { get; set; }
        public string shiftTypeName { get; set; }
        public string scheduleName { get; set; }
        public string description { get; set; }
        public string startTime { get; set; }
        public DateTime? startTimeLongFormat { get; set; }
        public string endTime { get; set; }
        public DateTime? endTimeLongFormat { get; set; }
        public int? shiftScheduleTakeId { get; set; }
        public Guid? memberId { get; set; }
        public int shiftScheduleId { get; set; }
        public string scheduleDate { get; set; }
        public bool? isTaken { get; set; }
        public int? status { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string badgeNumber { get; set; }
        public int? shiftSchedulePlanId { get; set; }
        public string phoneNumber { get; set; }
        public int? dayOfWeek { get; set; }
        public bool? isCustom { get; set; }
        public int? customId { get; set; }
    }
}
