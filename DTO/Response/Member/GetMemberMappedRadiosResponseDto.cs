namespace DTO.Response.Member
{
    public class GetMemberMappedRadiosResponseDto
    {
        public int radioId { get; set; }
        public Guid memberId { get; set; }
        public string audioFrom { get; set; }
    }
}
