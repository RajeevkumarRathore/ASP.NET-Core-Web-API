namespace DTO.Request.Header
{
    public class ChatMessageHistoryRequestDto
    {

        public int userId { get; set; }
        public int agencyId { get; set; }
        public string searchText { get; set; }
        public bool isMember { get; set; }
        public int startRow { get; set; }
        public int endRow { get; set; }
    }
}

