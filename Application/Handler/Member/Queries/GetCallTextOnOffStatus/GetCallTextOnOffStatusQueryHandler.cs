using Application.Abstraction.Services;
using DTO.Request.Member;
using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Queries.GetCallTextOnOffStatus
{
    public class GetCallTextOnOffStatusQueryHandler : IRequestHandler<GetCallTextOnOffStatusQuery, CommonResultResponseDto<CallTextOnOffStatusRequestDto>>
    {
        private readonly IMemberService _memberService;
        public GetCallTextOnOffStatusQueryHandler(IMemberService memberService)
        {
            _memberService = memberService;   
        }
        public async Task<CommonResultResponseDto<CallTextOnOffStatusRequestDto>> Handle(GetCallTextOnOffStatusQuery request, CancellationToken cancellationToken)
        {
            return await _memberService.GetCallTextOnOffStatus();
        }
    }
}
