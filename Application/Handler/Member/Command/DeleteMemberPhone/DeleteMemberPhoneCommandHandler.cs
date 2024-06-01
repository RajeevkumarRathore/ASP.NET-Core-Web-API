using Application.Abstraction.Services;
using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Command.DeleteMemberPhone
{
    public class DeleteMemberPhoneCommandHandler : IRequestHandler<DeleteMemberPhoneCommand, CommonResultResponseDto<string>>
    {
        private readonly IMemberService _memberService;
        public DeleteMemberPhoneCommandHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(DeleteMemberPhoneCommand  deleteMemberPhoneCommand, CancellationToken cancellationToken)
        {
            return await _memberService.DeleteMemberPhone(deleteMemberPhoneCommand.MemberPhoneId);
        }
    }
}
