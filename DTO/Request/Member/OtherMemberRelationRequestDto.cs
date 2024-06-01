namespace DTO.Request.Member
{
    public class OtherMemberRelationRequestDto
    {
        public Guid relatedMember { get; set; }
        public Guid currentMember { get; set; }
    }
}
