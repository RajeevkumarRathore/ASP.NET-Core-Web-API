using Domain.Entities;

namespace DTO.Response.Header
{
    public class HospitalResponseDto
    {
        public Hospital Hospital { get; set; }
        public DispatchNotificationResponseDto DispatchNotificationResponse { get; set; }
        public bool? fromGoogle { get; set; }
    }
}
