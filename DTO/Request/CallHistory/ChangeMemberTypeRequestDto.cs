namespace DTO.Request.CallHistory
{
    public class ChangeMemberTypeRequestDto
    {
        public int clientId { get; set; }
        public Guid memberId { get; set; }
        public string type { get; set; }
        public bool isNotificationTemporarySwitchOn { get; set; }
        public string currentUsername { get; set; }
    }
}
