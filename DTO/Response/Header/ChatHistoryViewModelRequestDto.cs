namespace DTO.Response.Header
{
    public class ChatHistoryViewModelRequestDto
    {
        public int TotalResult { get; set; }
        public List<ChatHistoryViewModel> chatHistoryDto { get; set; }
    }
}
