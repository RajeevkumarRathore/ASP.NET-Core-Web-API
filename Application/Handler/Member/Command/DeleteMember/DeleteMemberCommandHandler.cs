using Application.Abstraction.Services;
using Application.Handler.Header.Command.DeleteDispatchNotification;
using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Command.DeleteMember
{
    public class DeleteMemberCommandHandler : IRequestHandler<DeleteMemberCommand, CommonResultResponseDto<string>>
    {
        private readonly IMemberService _memberService;
        public DeleteMemberCommandHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(DeleteMemberCommand deleteMemberCommand, CancellationToken cancellationToken)
        {
            return await _memberService.DeleteMember(deleteMemberCommand.user_id);
        }
    }
}
