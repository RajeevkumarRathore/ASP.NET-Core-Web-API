namespace DTO.Response.Member
{
    public class GetMemberViewModelResponseDto
    {
        public int TotalCounts { get; set; }
        public List<ResMemberViewModel> Members { get; set; }
    }
}
