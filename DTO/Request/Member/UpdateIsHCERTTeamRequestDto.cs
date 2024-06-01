namespace DTO.Request.Member
{
    public class UpdateIsHCERTTeamRequestDto
    {
        public Guid user_id { get; set; }
        public bool isHCERTTeam { get; set; }
    }
}
