
namespace DTO.Response.ShiftSchedules
{
    public class AllMembersClassifiedForShiftResponseDto
    {
        public List<RelatedMembersResponseDto> DispatcherMembers { get; set; }
        public List<RelatedMembersResponseDto> EmsMembers { get; set; }
        public List<RelatedMembersResponseDto> AlsMembers { get; set; }
        public List<RelatedMembersResponseDto> FireMembers { get; set; }
    }
}
