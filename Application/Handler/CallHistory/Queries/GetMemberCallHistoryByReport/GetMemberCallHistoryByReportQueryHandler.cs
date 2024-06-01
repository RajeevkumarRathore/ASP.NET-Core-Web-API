using DTO.Response.CallHistory;
using DTO.Response;
using MediatR;
using Application.Abstraction.Services;
using DTO.Request.CallHistory;
using Mapster;

namespace Application.Handler.CallHistory.Queries.GetMemberCallHistoryByReport
{
    public class GetMemberCallHistoryByReportQueryHandler : IRequestHandler<GetMemberCallHistoryByReportQuery, CommonResultResponseDto<List<GetMemberCallHistoryReportResponseDto>>>
    {
        private readonly IMemberService _memberService;
        public GetMemberCallHistoryByReportQueryHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }

        public async Task<CommonResultResponseDto<List<GetMemberCallHistoryReportResponseDto>>> Handle(GetMemberCallHistoryByReportQuery  getMemberCallHistoryByReportQuery, CancellationToken cancellationToken)
        {
            return await _memberService.GetMemberCallHistoryByReport(getMemberCallHistoryByReportQuery.Adapt<MemberCallHistoryByReportRequestDto>());
        }
    }
}
