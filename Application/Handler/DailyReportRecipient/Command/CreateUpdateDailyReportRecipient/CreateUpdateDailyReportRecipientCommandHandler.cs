using DTO.Response;
using MediatR;
using DTO.Response.DailyReportRecipient;
using Application.Abstraction.Services;
using DTO.Request.DailyReportRecipient;
using Mapster;

namespace Application.Handler.DailyReportRecipient.Command.CreateUpdateDailyReportRecipient
{
    public class CreateUpdateDailyReportRecipientCommandHandler : IRequestHandler<CreateUpdateDailyReportRecipientCommand, CommonResultResponseDto<CreateUpdateDailyReportRecipientResponseDto>>
    {
        private readonly IDailyReportRecipientService _dailyReportRecipientService;

        public CreateUpdateDailyReportRecipientCommandHandler(IDailyReportRecipientService dailyReportRecipientService)
        {
            _dailyReportRecipientService = dailyReportRecipientService;
        }
        public async  Task<CommonResultResponseDto<CreateUpdateDailyReportRecipientResponseDto>> Handle(CreateUpdateDailyReportRecipientCommand createUpdateDailyReportRecipientCommand, CancellationToken cancellationToken)
        {
            return await _dailyReportRecipientService.CreateUpdateDailyReportRecipient(createUpdateDailyReportRecipientCommand.Adapt<CreateUpdateDailyReportRecipientRequestDto>());
        }
    }
}
