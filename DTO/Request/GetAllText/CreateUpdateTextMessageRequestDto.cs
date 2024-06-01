namespace DTO.Request.GetAllText
{
    public class CreateUpdateTextMessageRequestDto
    {
        public int Id { get; set; }
        public string ShortText { get; set; }
        public string FullText { get; set; }
        public string Type { get; set; }
    }
}
