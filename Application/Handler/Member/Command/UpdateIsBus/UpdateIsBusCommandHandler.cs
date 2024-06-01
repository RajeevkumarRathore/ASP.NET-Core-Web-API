using Application.Abstraction.Services;
using Application.Handler.Member.Command.UpdateIsDispatcher;
using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Command.UpdateIsBus
{
    public class UpdateIsBusCommandHandler : IRequestHandler<UpdateIsBusCommand, CommonResultResponseDto<string>>
    {
        private readonly IMemberService _memberService;
        public UpdateIsBusCommandHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(UpdateIsBusCommand updateIsBusCommand, CancellationToken cancellationToken)
        {
            return await _memberService.UpdateIsBus(updateIsBusCommand.user_id, updateIsBusCommand.isBus);
        }
    }
}
