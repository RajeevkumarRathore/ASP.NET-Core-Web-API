

using Domain.Entities;
using DTO.Response;
using DTO.Response.CallHistory;
using MediatR;

namespace Application.Handler.Member.Queries.GetMemberCallHistory
{
    public class GetMemberCallHistoryQuery : IRequest<CommonResultResponseDto<IList<GetMemberCallHistoryReportResponseDto>>>
    {
        public Guid memberId { get; set; }
    }
}
