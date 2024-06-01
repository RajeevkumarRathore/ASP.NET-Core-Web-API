namespace DTO.Request.DailyReportRecipient
{
    public class CreateUpdateDailyReportRecipientRequestDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public bool IsDailyRecipient { get; set; }
        public bool IsWeeklyRecipient { get; set; }
    }
}

