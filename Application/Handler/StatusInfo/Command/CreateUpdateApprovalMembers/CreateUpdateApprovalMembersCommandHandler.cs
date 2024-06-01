using Application.Abstraction.Services;
using DTO.Request.StatusInfo;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.StatusInfo.Command.CreateUpdateApprovalMembers
{
    public class CreateUpdateApprovalMembersCommandHandler : IRequestHandler<CreateUpdateApprovalMembersCommand, CommonResultResponseDto<string>>
    {
        private readonly IStatusInfoService _statusInfoService;
        public CreateUpdateApprovalMembersCommandHandler(IStatusInfoService statusInfoService)
        {
            _statusInfoService = statusInfoService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(CreateUpdateApprovalMembersCommand createApprovedByCommand, CancellationToken cancellationToken)
        {
            return await _statusInfoService.CreateUpdateApprovalMembers(createApprovedByCommand.Adapt<ApprovalMemberRequestDto>());
        }
    }
}
