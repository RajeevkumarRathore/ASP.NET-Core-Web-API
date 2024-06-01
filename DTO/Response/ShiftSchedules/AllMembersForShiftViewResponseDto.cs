namespace DTO.Response.ShiftSchedules
{
    public class AllMembersForShiftViewResponseDto
    {
        public Guid userId { get; set; }
        public string badgeNumber { get; set; }
        public bool? isDispatcher { get; set; }
        public string emergencyType { get; set; }
        public string expertise { get; set; }
    }
}
