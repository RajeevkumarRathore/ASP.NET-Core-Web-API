
namespace DTO.Request.Twilio
{
    public class GetNotificationDtoForMemberRequest
    {
        public int clientId { get; set; }
        public Guid? memberId { get; set; }
    }
}
