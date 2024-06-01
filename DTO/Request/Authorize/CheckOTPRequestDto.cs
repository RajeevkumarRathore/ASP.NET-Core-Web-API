namespace DTO.Request.Authorize
{
    public class CheckOTPRequestDto
    {
        public string username { get; set; }
        public string phone { get; set; }
        public int otp { get; set; }
    }
}
