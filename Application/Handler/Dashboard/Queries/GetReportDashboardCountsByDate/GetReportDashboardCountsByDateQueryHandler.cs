using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.Dashboard;
using MediatR;

namespace Application.Handler.Dashboard.Queries.GetReportDashboardCountsByDate
{
    public class GetReportDashboardCountsByDateQueryHandler : IRequestHandler<GetReportDashboardCountsByDateQuery, CommonResultResponseDto<List<GetReportDashboardCountsByDateResponseDto>>>
    {
        private readonly IClientService  _clientService;
        public GetReportDashboardCountsByDateQueryHandler(IClientService  clientService)
        {
            _clientService = clientService;
        }
        public async Task<CommonResultResponseDto<List<GetReportDashboardCountsByDateResponseDto>>> Handle(GetReportDashboardCountsByDateQuery  getReportDashboardCountsByDateQuery, CancellationToken cancellationToken)
        {
            return await _clientService.GetReportDashboardCountsByDate(getReportDashboardCountsByDateQuery.StartDate,getReportDashboardCountsByDateQuery.EndDate);
        }
    }
}
