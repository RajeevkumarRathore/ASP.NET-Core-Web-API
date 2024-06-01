using Application.Abstraction.Services;
using Application.Handler.Member.Command.UpdateIsBus;
using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Command.UpdateIsRegular
{
    public class UpdateIsRegularCommandHandler : IRequestHandler<UpdateIsRegularCommand, CommonResultResponseDto<string>>
    {
        private readonly IMemberService _memberService;
        public UpdateIsRegularCommandHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(UpdateIsRegularCommand updateIsRegularCommand, CancellationToken cancellationToken)
        {
            return await _memberService.UpdateIsRegular(updateIsRegularCommand.user_id, updateIsRegularCommand.isRegular);
        }
    }
}
