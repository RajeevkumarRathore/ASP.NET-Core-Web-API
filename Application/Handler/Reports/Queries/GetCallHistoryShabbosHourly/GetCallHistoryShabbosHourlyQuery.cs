using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response.Report;
using DTO.Response;
using MediatR;

namespace Application.Handler.Reports.Queries.GetCallHistoryShabbosHourly
{
    public class GetCallHistoryShabbosHourlyQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<GetCallHistoryShabbosHourlyResponseDto>>>
    {
        public string fromTime { get; set; }
        public string toTime { get; set; }
        public bool IsShabbosOnly { get; set; }
        public ServerRowsRequest CommonRequest { get; set; }
    }
}
