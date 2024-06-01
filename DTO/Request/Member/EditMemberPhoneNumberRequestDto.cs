namespace DTO.Request.Member
{
    public class EditMemberPhoneNumberRequestDto
    {
        public int memberPhoneId { get; set; }
        public Guid memberId { get; set; }
        public string phoneNumber { get; set; }
    }
}
