

using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Command.UpdateRelatedMemberId
{
    public class UpdateRelatedMemberIdCommand : IRequest<CommonResultResponseDto<string>>
    {
        public Guid relatedMember { get; set; }
        public Guid currentMember { get; set; }
    }
}
