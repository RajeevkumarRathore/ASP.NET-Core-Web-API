namespace DTO.Request.Member
{
    public class ExpertisesUpdateRequestDto
    {
        public Guid memberId { get; set; }
        public List<int> expertisesIds { get; set; }
    }
}
