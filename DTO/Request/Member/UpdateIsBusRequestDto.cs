namespace DTO.Request.Member
{
    public class UpdateIsBusRequestDto
    {
        public Guid user_id { get; set; }
        public bool isBus { get; set; }
    }
}
