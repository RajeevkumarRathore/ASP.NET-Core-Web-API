using Application.Abstraction.Services;
using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Command.UpdateIsReceivingPhoneCalls
{
    public class UpdateIsReceivingPhoneCallsCommandHandler : IRequestHandler<UpdateIsReceivingPhoneCallsCommand, CommonResultResponseDto<string>>
    {
        private readonly IMemberService _memberService;
        public UpdateIsReceivingPhoneCallsCommandHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(UpdateIsReceivingPhoneCallsCommand  updateIsReceivingPhoneCallsCommand, CancellationToken cancellationToken)
        {
            return await _memberService.UpdateIsReceivingPhoneCalls(updateIsReceivingPhoneCallsCommand.user_id,updateIsReceivingPhoneCallsCommand.isReceivingPhoneCalls);
        }
    }
}
