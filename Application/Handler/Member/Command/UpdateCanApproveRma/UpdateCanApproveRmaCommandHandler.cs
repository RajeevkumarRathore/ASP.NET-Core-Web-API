using Application.Abstraction.Services;
using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Command.UpdateCanApproveRma
{
    public class UpdateCanApproveRmaCommandHandler : IRequestHandler<UpdateCanApproveRmaCommand, CommonResultResponseDto<string>>
    {
        private readonly IMemberService _memberService;
        public UpdateCanApproveRmaCommandHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(UpdateCanApproveRmaCommand updateCanApproveRmaCommand, CancellationToken cancellationToken)
        {
            return await _memberService.UpdateCanApproveRma(updateCanApproveRmaCommand.user_id, updateCanApproveRmaCommand.canApproveRma);
        }
    }
}
