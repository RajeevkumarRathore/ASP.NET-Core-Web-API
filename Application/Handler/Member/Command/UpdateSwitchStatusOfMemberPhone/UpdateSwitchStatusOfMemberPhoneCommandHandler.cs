using Application.Abstraction.Services;
using DTO.Request.Member;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Member.Command.UpdateSwitchStatusOfMemberPhone
{
    public class UpdateSwitchStatusOfMemberPhoneCommandHandler : IRequestHandler<UpdateSwitchStatusOfMemberPhoneCommand, CommonResultResponseDto<string>>
    {
        private readonly IMemberService _memberService;
        public UpdateSwitchStatusOfMemberPhoneCommandHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(UpdateSwitchStatusOfMemberPhoneCommand updateSwitchStatusOfMemberPhoneCommand, CancellationToken cancellationToken)
        {
            return await _memberService.UpdateSwitchStatusOfMemberPhone(updateSwitchStatusOfMemberPhoneCommand.Adapt<UpdateActivePhoneRequestDto>());
        }
    }
}
