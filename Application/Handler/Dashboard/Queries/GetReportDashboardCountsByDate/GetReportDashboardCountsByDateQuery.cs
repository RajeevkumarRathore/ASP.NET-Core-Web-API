using DTO.Response;
using DTO.Response.Dashboard;
using MediatR;

namespace Application.Handler.Dashboard.Queries.GetReportDashboardCountsByDate
{
    public class GetReportDashboardCountsByDateQuery : IRequest<CommonResultResponseDto<List<GetReportDashboardCountsByDateResponseDto>>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
