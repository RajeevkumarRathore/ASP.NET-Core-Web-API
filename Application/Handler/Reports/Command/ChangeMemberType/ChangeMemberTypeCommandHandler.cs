using Application.Abstraction.Services;
using DTO.Request.CallHistory;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Reports.Command.ChangeMemberType
{
    public class ChangeMemberTypeCommandHandler : IRequestHandler<ChangeMemberTypeCommand, CommonResultResponseDto<string>>
    {
        private readonly IReportService _reportService;
        public ChangeMemberTypeCommandHandler(IReportService reportService)
        {
            _reportService = reportService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(ChangeMemberTypeCommand  changeMemberTypeCommand, CancellationToken cancellationToken)
        {
            return await _reportService.ChangeMemberType(changeMemberTypeCommand.Adapt<ChangeMemberTypeRequestDto>());
        }
    }
}
