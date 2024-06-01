using Application.Abstraction.Services;
using DTO.Request.Member;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Member.Command.AddPhoneToMember
{
    public class AddPhoneToMemberCommandHandler : IRequestHandler<AddPhoneToMemberCommand, CommonResultResponseDto<string>>
    {
        private readonly IMemberService _memberService;
        public AddPhoneToMemberCommandHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(AddPhoneToMemberCommand  addPhoneToMemberCommand, CancellationToken cancellationToken)
        {
            return await _memberService.AddPhoneToMember(addPhoneToMemberCommand.Adapt<AddPhoneToMemberRequestDto>());
        }
    }
}
