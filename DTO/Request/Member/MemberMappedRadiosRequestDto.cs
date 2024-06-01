namespace DTO.Request.Member
{
    public class MemberMappedRadiosRequestDto
    {
        public int radioId { get; set; }
        public Guid memberId { get; set; }
        public string audioFrom { get; set; }
    }
}
