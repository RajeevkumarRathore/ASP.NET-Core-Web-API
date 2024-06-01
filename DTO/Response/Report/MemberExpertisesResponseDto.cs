namespace DTO.Response.Report
{
    public class MemberExpertisesResponseDto
    {
        public int Id { get; set; }

        public Guid Membersuser_id { get; set; }

        public int? ExpertisesId { get; set; }
        public string expertiseName { get; set; }
    }
}
