using Application.Abstraction.Services;
using DTO.Request.CallHistory;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Reports.Command.AddCallHistoryNote
{
    public class AddCallHistoryNoteCommandHandler : IRequestHandler<AddCallHistoryNoteCommand, CommonResultResponseDto<string>>
    {
        private readonly IReportService _reportService;
        public AddCallHistoryNoteCommandHandler(IReportService reportService)
        {
            _reportService = reportService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(AddCallHistoryNoteCommand addCallHistoryNoteCommand, CancellationToken cancellationToken)
        {
            return await _reportService.AddCallHistoryNote(addCallHistoryNoteCommand.Adapt<AddCallHistoryNoteRequestDto>());
        }
    }
}
