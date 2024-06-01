using Application.Abstraction.Services;
using DTO.Response;
using MediatR;

namespace Application.Handler.StatusInfo.Command.DeleteApprovalMember
{
    public class DeleteApprovalMemberCommandHandler : IRequestHandler<DeleteApprovalMemberCommand, CommonResultResponseDto<string>>
    {
        private readonly IStatusInfoService _statusInfoService;
        public DeleteApprovalMemberCommandHandler(IStatusInfoService statusInfoService)
        {
            _statusInfoService = statusInfoService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(DeleteApprovalMemberCommand deleteApprovalMemberByIdCommand, CancellationToken cancellationToken)
        {
            return await _statusInfoService.DeleteApprovalMember(deleteApprovalMemberByIdCommand.Id);
        }
    }
}
