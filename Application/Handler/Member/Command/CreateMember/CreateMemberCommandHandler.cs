using Application.Abstraction.Services;
using DTO.Request.Member;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Member.Command.CreateMember
{
    public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, CommonResultResponseDto<string>>
    {
        private readonly IMemberService _memberService;
        public CreateMemberCommandHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(CreateMemberCommand  createMemberCommand, CancellationToken cancellationToken)
        {
            return await _memberService.CreateMember(createMemberCommand.Adapt<MemberCreateRequestDto>());
        }
    }
}
