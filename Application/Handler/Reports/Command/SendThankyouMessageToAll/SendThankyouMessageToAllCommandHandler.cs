using Application.Abstraction.Services;
using DTO.Request.Report;
using DTO.Response;
using DTO.Response.Report;
using Mapster;
using MediatR;

namespace Application.Handler.Reports.Command.SendThankyouMessageToAll
{
    public class SendThankyouMessageToAllCommandHandler : IRequestHandler<SendThankyouMessageToAllCommand, CommonResultResponseDto<List<SendThankyouMessageToAllCommandResponseDto>>>
    {
        private readonly IReportService _reportService;
        public SendThankyouMessageToAllCommandHandler(IReportService reportService)
        {
            _reportService = reportService;
        }
        public async Task<CommonResultResponseDto<List<SendThankyouMessageToAllCommandResponseDto>>> Handle(SendThankyouMessageToAllCommand  sendThankyouMessageToAllCommand, CancellationToken cancellationToken)
        {
            return await _reportService.SendThankyouMessageToAll(string.Empty, sendThankyouMessageToAllCommand.Adapt<MonthlyThankYouMessageDateRequestDto>());
        }
    }
}
