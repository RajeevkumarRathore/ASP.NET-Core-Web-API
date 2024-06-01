
using Application.Abstraction.Services;
using DTO.Request.Member;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Member.Command.UpdateGeneralNotificationsOnOffStatus
{
    public class UpdateGeneralNotificationsOnOffStatusCommandHandler : IRequestHandler<UpdateGeneralNotificationsOnOffStatusCommand, CommonResultResponseDto<GetNotificationsOnOffStatusRequest>>
    {
        private readonly IMemberService _memberService;
        public UpdateGeneralNotificationsOnOffStatusCommandHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<CommonResultResponseDto<GetNotificationsOnOffStatusRequest>> Handle(UpdateGeneralNotificationsOnOffStatusCommand  updateGeneralNotificationsOnOffStatusCommand, CancellationToken cancellationToken)
        {
            return await _memberService.UpdateGeneralNotificationsOnOffStatus(updateGeneralNotificationsOnOffStatusCommand.Adapt<GetNotificationsOnOffStatusRequest>());
        }
    }
}
