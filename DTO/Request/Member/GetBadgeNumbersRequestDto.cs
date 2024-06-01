namespace DTO.Request.Member
{
    public class GetBadgeNumbersRequestDto
    {
        public Guid userId { get; set; }
        public string badgeNumber { get; set; }
        public int emergencyTypeId { get; set; }
    }
}
