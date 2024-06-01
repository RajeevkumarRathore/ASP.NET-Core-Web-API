namespace DTO.Request.Member
{
    public class UpdateCanApproveRmaRequestDto
    {
        public Guid user_id { get; set; }
        public bool canApproveRma { get; set; }
    }
}
