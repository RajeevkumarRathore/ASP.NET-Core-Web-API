
namespace Application.Handler.Header.Dtos
{
    public class NotificationDto
    {
        public int id { get; set; }
        public string text_message { get; set; }
        public string notify_number { get; set; }
        public Guid? memberId { get; set; }
    }
}
