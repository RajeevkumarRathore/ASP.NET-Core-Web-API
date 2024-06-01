namespace DTO.Request.Report
{
    public class BusDriverNotificationDto
    {
        public int? shiftScheduleTakesId { get; set; }
        public string phoneNumber { get; set; }
        public string textMessage { get; set; }
        public Guid? memberid { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
    }
}
