namespace DTO.Request.Header
{
    public class TwilioMessagesChatRequest
    {
        public string phone { get; set; }
        public string message { get; set; }
        public string memberId { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int selectedClientId { get; set; }
        public int memberAdditionId { get; set; }
        public string sid { get; set; }
    }
}
