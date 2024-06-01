using Application.Abstraction.Services;
using DTO.Response.CallHistory;
using DTO.Response;
using MediatR;
using DTO.Request.CallHistory;
using Mapster;

namespace Application.Handler.CallHistory.Queries.GetMemberCallHistoryReportByBadge
{
    public class GetMemberCallHistoryReportByBadgeQueryHandler : IRequestHandler<GetMemberCallHistoryReportByBadgeQuery, CommonResultResponseDto<GetMemberCallHistoryReportByBadgeResponseDto>>
    {
        private readonly IMemberService _memberService;
        public GetMemberCallHistoryReportByBadgeQueryHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<CommonResultResponseDto<GetMemberCallHistoryReportByBadgeResponseDto>> Handle(GetMemberCallHistoryReportByBadgeQuery getMemberCallHistoryReportByBadgeQuery, CancellationToken cancellationToken)
        {
            return await _memberService.GetMemberCallHistoryReportByBadge(getMemberCallHistoryReportByBadgeQuery.Adapt<MemberCallHistoryReportByBadgeRequestDto>());
        }
    }
}
