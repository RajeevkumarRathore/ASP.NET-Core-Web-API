namespace DTO.Response.CallHistory
{
    public class CallHistoryCountsResponseDto
    {
        public int total_cause { get; set; }
        public int open_cause { get; set; }
        public int complated_cause { get; set; }
        public int cancel_cause { get; set; }
        public int fire_cause { get; set; }
        public int medical_cause { get; set; }
    }
}
