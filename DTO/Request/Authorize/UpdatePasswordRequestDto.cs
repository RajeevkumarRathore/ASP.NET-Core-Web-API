namespace DTO.Request.Authorize
{
    public class UpdatePasswordRequestDto
    {
        public string username { get; set; }
        public string phone { get; set; }
        public string otp { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
    }
}
