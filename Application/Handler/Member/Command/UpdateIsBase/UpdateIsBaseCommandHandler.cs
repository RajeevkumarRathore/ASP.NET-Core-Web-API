using Application.Abstraction.Services;
using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Command.UpdateIsBase
{
    public class UpdateIsBaseCommandHandler : IRequestHandler<UpdateIsBaseCommand, CommonResultResponseDto<string>>
    {
        private readonly IMemberService _memberService;
        public UpdateIsBaseCommandHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(UpdateIsBaseCommand updateIsBaseCommand, CancellationToken cancellationToken)
        {
            return await _memberService.UpdateIsBase(updateIsBaseCommand.user_id, updateIsBaseCommand.isBase);
        }
    }
}
