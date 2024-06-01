
using Application.Abstraction.Services;
using Application.Handler.Member.Command.ExpertisesUpdate;
using DTO.Request.Member;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Member.Command.AddMemberRadio
{
    public class AddMemberRadioCommandHandler : IRequestHandler<AddMemberRadioCommand, CommonResultResponseDto<string>>
    {
        private readonly IMemberService _memberService;
        public AddMemberRadioCommandHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(AddMemberRadioCommand  addMemberRadioCommand, CancellationToken cancellationToken)
        {
            return await _memberService.AddMemberRadio(addMemberRadioCommand.Adapt<MemberMappedRadiosRequestDto>());
        }
    }
}
