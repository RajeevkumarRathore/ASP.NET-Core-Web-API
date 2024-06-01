

namespace DTO.Response.DailyReportRecipient
{
    public class CreateUpdateDailyReportRecipientResponseDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsDailyRecipient { get; set; }
        public bool? IsWeeklyRecipient { get; set; }
    }
}
