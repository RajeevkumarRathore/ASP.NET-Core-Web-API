using Application.Abstraction.Services;
using Application.Common.Response;
using DTO.Request.Dashboard;
using DTO.Response;
using DTO.Response.Dashboard;
using Mapster;
using MediatR;

namespace Application.Handler.Dashboard.Queries.GetMembersTopResponderReport
{
    public class GetMembersTopResponderReportQueryHandler : IRequestHandler<GetMembersTopResponderReportQuery, CommonResultResponseDto<PaginatedList<GetMembersTopResponderReportResponseDto>>>
    {
        private readonly IMemberService  _memberService;
        public GetMembersTopResponderReportQueryHandler(IMemberService  memberService)
        {
            _memberService = memberService;
        }
        public async Task<CommonResultResponseDto<PaginatedList<GetMembersTopResponderReportResponseDto>>> Handle(GetMembersTopResponderReportQuery getMembersTopResponderReportCommand, CancellationToken cancellationToken)
        {
            return await _memberService.GetMembersTopResponderReport(getMembersTopResponderReportCommand.Adapt<MembersTopRequestDto>());

        }
    }

    
}

