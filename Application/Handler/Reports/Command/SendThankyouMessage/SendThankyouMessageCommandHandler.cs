using Application.Abstraction.Services;
using Domain.Entities;
using DTO.Request.Report;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Reports.Command.SendThankyouMessage
{
    public class SendThankyouMessageCommandHandler : IRequestHandler<SendThankyouMessageCommand, CommonResultResponseDto<Members>>
    {
        private readonly IReportService _reportService;
        public SendThankyouMessageCommandHandler(IReportService reportService)
        {
            _reportService = reportService;
        }
        public async Task<CommonResultResponseDto<Members>> Handle(SendThankyouMessageCommand  sendThankyouMessageCommand, CancellationToken cancellationToken)
        {
            return await _reportService.SendThankyouMessage(sendThankyouMessageCommand.Adapt<ThankYouMessageRequestDto>());
        }
    }
}
