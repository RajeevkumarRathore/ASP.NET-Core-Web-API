using Application.Abstraction.Services;
using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Command.UpdateIsTakingShifts
{
    public class UpdateIsTakingShiftsCommandHandler : IRequestHandler<UpdateIsTakingShiftsCommand, CommonResultResponseDto<string>>
    {
        private readonly IMemberService _memberService;
        public UpdateIsTakingShiftsCommandHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(UpdateIsTakingShiftsCommand  updateIsTakingShiftsCommand, CancellationToken cancellationToken)
        {
            return await _memberService.UpdateIsTakingShifts(updateIsTakingShiftsCommand.user_id, updateIsTakingShiftsCommand.isTakingShifts);
        }
    }
}
