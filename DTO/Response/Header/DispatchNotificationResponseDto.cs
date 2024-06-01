namespace DTO.Response.Header
{
    public class DispatchNotificationResponseDto
    {
        public int DispatchNotificationId { get; set; }
        public int? HospitalId { get; set; }
        public int CreatedBy { get; set; }
        public string DispatchNotificationText { get; set; }
        public string EffectiveUntill { get; set; }
        public int dispatcherNotificationDaySelect { get; set; }
        public string HospitalName { get; set; }
        public string CreaterName { get; set; }
        public string SelectedDay { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
