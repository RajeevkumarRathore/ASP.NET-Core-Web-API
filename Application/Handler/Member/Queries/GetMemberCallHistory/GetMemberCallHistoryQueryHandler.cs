

using Application.Abstraction.Services;
using Application.Handler.Member.Queries.GetMemberCounts;
using Domain.Entities;
using DTO.Response;
using DTO.Response.CallHistory;
using MediatR;

namespace Application.Handler.Member.Queries.GetMemberCallHistory
{
    public class GetMemberCallHistoryQueryHandler : IRequestHandler<GetMemberCallHistoryQuery, CommonResultResponseDto<IList<GetMemberCallHistoryReportResponseDto>>>
    {
        private readonly IMemberService _memberService;
        public GetMemberCallHistoryQueryHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<CommonResultResponseDto<IList<GetMemberCallHistoryReportResponseDto>>> Handle(GetMemberCallHistoryQuery  getMemberCallHistoryQuery, CancellationToken cancellationToken)
        {
            return await _memberService.GetMemberCallHistory(getMemberCallHistoryQuery.memberId);
        }
    }
}
