namespace DTO.Request.Member
{
    public class UpdateReceivingPhoneCallsRequestDto
    {
        public Guid user_id { get; set; }
        public bool isReceivingPhoneCalls { get; set; }
    }
}
