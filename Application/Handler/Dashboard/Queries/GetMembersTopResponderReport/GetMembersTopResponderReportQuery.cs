using Application.Common.Response;
using DTO.Response;
using DTO.Response.Dashboard;
using MediatR;

namespace Application.Handler.Dashboard.Queries.GetMembersTopResponderReport
{
    public class GetMembersTopResponderReportQuery : IRequest<CommonResultResponseDto<PaginatedList<GetMembersTopResponderReportResponseDto>>>
    {
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string? DayCallFromtime { get; set; }
        public string? DayCallTotime { get; set; }
        public string? NightCallFromtime { get; set; }
        public string? NightCallTotime { get; set; }
    }
    

}

