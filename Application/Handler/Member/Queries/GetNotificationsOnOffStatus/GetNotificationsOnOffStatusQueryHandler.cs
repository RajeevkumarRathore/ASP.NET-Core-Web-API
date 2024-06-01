

using Application.Abstraction.Services;
using Application.Handler.Member.Queries.GetCallTextOnOffStatus;
using DTO.Request.Member;
using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Queries.GetNotificationsOnOffStatus
{
    public class GetNotificationsOnOffStatusQueryHandler : IRequestHandler<GetNotificationsOnOffStatusQuery, CommonResultResponseDto<GetNotificationsOnOffStatusRequest>>
    {
        private readonly IMemberService _memberService;
        public GetNotificationsOnOffStatusQueryHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<CommonResultResponseDto<GetNotificationsOnOffStatusRequest>> Handle(GetNotificationsOnOffStatusQuery request, CancellationToken cancellationToken)
        {
            return await _memberService.GetNotificationsOnOffStatus();
        }
    }
}
