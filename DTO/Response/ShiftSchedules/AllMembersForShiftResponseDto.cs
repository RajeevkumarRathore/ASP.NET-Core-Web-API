namespace DTO.Response.ShiftSchedules
{
    public class AllMembersForShiftResponseDto
    {
        public AllMembersForShiftResponseDto()
        {
            EmsMembers = new List<RelatedMembersResponseDto>();
            allMembersResponseForShiftViewModels = new List<AllMembersForShiftViewResponseDto>();
        }

        public List<RelatedMembersResponseDto> EmsMembers { get; set; }
        public List<AllMembersForShiftViewResponseDto> allMembersResponseForShiftViewModels { get; set; }
    }
}
