namespace DTO.Response.User
{
    public class ValidateResponseDto<T> where T : class
    {
        public T data { get; set; }
        public string message { get; set; }
        public bool isValid { get; set; }
    }
}
