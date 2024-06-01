namespace DTO.Request.Header
{
    public class GetChatAllRequestDto
    {
        public string SearchText { get; set; }
        public bool IsMember { get; set; }
        public int StartRow { get; set; }
        public int EndRow { get; set; }
    }
}
