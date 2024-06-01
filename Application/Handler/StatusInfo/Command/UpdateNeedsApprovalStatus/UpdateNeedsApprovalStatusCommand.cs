using DTO.Response;
using MediatR;

namespace Application.Handler.StatusInfo.Command.UpdateNeedsApprovalStatus
{
    public class UpdateNeedsApprovalStatusCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int Id { get; set; }
        public bool NeedsApproval { get; set; }
    }
}
