namespace DTO.Request.Member
{
    public class UpdateIsRegularRequestDto
    {
        public Guid user_id { get; set; }
        public bool isRegular { get; set; }
    }
}
