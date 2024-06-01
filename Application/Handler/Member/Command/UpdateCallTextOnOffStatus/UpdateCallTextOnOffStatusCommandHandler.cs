using Application.Abstraction.Services;
using DTO.Request.Member;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Member.Command.UpdateCallTextOnOffStatus
{
    public class UpdateCallTextOnOffStatusCommandHandler : IRequestHandler<UpdateCallTextOnOffStatusCommand, CommonResultResponseDto<CallTextOnOffStatusRequestDto>>
    {
        private readonly IMemberService _memberService;
        public UpdateCallTextOnOffStatusCommandHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<CommonResultResponseDto<CallTextOnOffStatusRequestDto>> Handle(UpdateCallTextOnOffStatusCommand updateCallTextOnOffStatusCommand, CancellationToken cancellationToken)
        {
            return await _memberService.UpdateCallTextOnOffStatus(updateCallTextOnOffStatusCommand.Adapt<CallTextOnOffStatusRequestDto>());
        }
    }
}
