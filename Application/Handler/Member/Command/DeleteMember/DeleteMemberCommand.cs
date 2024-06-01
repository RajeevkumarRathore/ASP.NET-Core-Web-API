using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Command.DeleteMember
{
    public class DeleteMemberCommand : IRequest<CommonResultResponseDto<string>>
    {
        public Guid user_id { get; set; }
    }
}
