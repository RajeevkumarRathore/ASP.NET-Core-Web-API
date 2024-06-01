namespace DTO.Request.Header
{
    public class ImportantNumberRequestDto
    {
        public string filter { get; set; }
        public string category { get; set; }
        public bool? fromAlert { get; set; } = false;
    }
}
