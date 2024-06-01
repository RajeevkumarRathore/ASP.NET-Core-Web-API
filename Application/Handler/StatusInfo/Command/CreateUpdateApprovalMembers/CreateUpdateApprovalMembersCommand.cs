using DTO.Response;
using MediatR;

namespace Application.Handler.StatusInfo.Command.CreateUpdateApprovalMembers
{
    public class CreateUpdateApprovalMembersCommand : IRequest<CommonResultResponseDto<string>>
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
    }
}
