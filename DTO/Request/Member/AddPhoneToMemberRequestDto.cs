namespace DTO.Request.Member
{
    public class AddPhoneToMemberRequestDto
    {
        public Guid MemberId { get; set; }
        public string Phone { get; set; }
    }
}
