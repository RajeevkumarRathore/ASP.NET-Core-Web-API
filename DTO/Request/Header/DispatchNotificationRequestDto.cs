namespace DTO.Request.Header
{
    public class DispatchNotificationRequestDto
    {
        public int? HospitalId { get; set; }
        public int CreatedBy { get; set; }
        public string DispatchNotificationText { get; set; }
        public string EffectiveUntill { get; set; }
        public int dispatcherNotificationDaySelect { get; set; }
        public bool isNotifyEveryone { get; set; }
        public DateTime? startTimeEffective { get; set; }
        public int? dispatcherNotificationMemberTypeSelect { get; set; }
    }
}
