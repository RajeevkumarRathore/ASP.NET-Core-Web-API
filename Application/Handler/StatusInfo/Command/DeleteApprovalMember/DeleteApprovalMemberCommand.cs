using DTO.Response;
using MediatR;

namespace Application.Handler.StatusInfo.Command.DeleteApprovalMember
{
    public class DeleteApprovalMemberCommand : IRequest<CommonResultResponseDto<string>>
    {
        public Guid Id { get; set; }
    }
}
