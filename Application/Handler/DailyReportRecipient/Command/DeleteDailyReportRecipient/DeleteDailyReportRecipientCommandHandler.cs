using Application.Abstraction.Services;
using DTO.Request.DailyReportRecipient;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.DailyReportRecipient.Command.DeleteDailyReportRecipient
{
    public class DeleteDailyReportRecipientCommandHandler : IRequestHandler<DeleteDailyReportRecipientCommand, CommonResultResponseDto<string>>
    {
        private readonly IDailyReportRecipientService _dailyReportRecipientService;

        public DeleteDailyReportRecipientCommandHandler(IDailyReportRecipientService dailyReportRecipientService)
        {
            _dailyReportRecipientService = dailyReportRecipientService;
        }

        public  async Task<CommonResultResponseDto<string>> Handle(DeleteDailyReportRecipientCommand deleteDailyReportRecipientCommand, CancellationToken cancellationToken)
        {
            return await _dailyReportRecipientService.DeleteDailyReportRecipient(deleteDailyReportRecipientCommand.Adapt<DeleteDailyReportRecipientRequestDto>());
        }
    }
}
