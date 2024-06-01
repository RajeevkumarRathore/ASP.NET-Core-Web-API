using DTO.Response;
using MediatR;
using DTO.Response.DailyReportRecipient;

namespace Application.Handler.DailyReportRecipient.Command.CreateUpdateDailyReportRecipient
{
    public class CreateUpdateDailyReportRecipientCommand : IRequest<CommonResultResponseDto<CreateUpdateDailyReportRecipientResponseDto>>
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public bool IsDailyRecipient { get; set; }
        public bool IsWeeklyRecipient { get; set; }
    }
}
