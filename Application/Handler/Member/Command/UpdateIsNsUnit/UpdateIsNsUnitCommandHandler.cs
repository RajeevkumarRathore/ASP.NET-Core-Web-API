using Application.Abstraction.Services;
using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Command.UpdateIsNsUnit
{
    public class UpdateIsNsUnitCommandHandler : IRequestHandler<UpdateIsNsUnitCommand, CommonResultResponseDto<string>>
    {
        private readonly IMemberService _memberService;
        public UpdateIsNsUnitCommandHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(UpdateIsNsUnitCommand updateIsNsUnitCommand, CancellationToken cancellationToken)
        {
            return await _memberService.UpdateIsNsUnit(updateIsNsUnitCommand.user_id, updateIsNsUnitCommand.isNsUnit);
        }
    }
}
