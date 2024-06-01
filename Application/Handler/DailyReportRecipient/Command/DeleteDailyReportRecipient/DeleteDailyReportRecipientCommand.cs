using DTO.Response;
using MediatR;

namespace Application.Handler.DailyReportRecipient.Command.DeleteDailyReportRecipient
{
    public class DeleteDailyReportRecipientCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int Id { get; set; }
    }
}
