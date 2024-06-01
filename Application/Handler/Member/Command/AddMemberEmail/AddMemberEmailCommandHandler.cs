
using Application.Abstraction.Services;
using Application.Handler.Member.Command.AddMemberRadio;
using DTO.Request.Member;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Member.Command.AddMemberEmail
{
    public class AddMemberEmailCommandHandler : IRequestHandler<AddMemberEmailCommand, CommonResultResponseDto<string>>
    {
        private readonly IMemberService _memberService;
        public AddMemberEmailCommandHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(AddMemberEmailCommand addMemberEmailCommand, CancellationToken cancellationToken)
        {
            return await _memberService.AddMemberEmail(addMemberEmailCommand.Adapt<AddMemberEmailRequestDto>());
        }
    }
}
