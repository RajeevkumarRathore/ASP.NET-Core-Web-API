using Application.Abstraction.Services;
using DTO.Request.StatusInfo;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.StatusInfo.Command.UpdateNeedsApprovalStatus
{
    public class UpdateNeedsApprovalStatusCommandHandler : IRequestHandler<UpdateNeedsApprovalStatusCommand, CommonResultResponseDto<string>>
    {
        private readonly IStatusInfoService _statusInfoService;
        public UpdateNeedsApprovalStatusCommandHandler(IStatusInfoService statusInfoService)
        {
            _statusInfoService = statusInfoService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(UpdateNeedsApprovalStatusCommand updateNeedsApprovalCommand, CancellationToken cancellationToken)
        {
            return await _statusInfoService.UpdateNeedsApprovalStatus(updateNeedsApprovalCommand.Adapt<UpdateNeedsApprovalStatusRequestDto>());
        }
    }
}
