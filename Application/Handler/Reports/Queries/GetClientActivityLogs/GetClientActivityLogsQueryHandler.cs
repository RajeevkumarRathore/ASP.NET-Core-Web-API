using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.Report;
using Mapster;
using MediatR;

namespace Application.Handler.Reports.Queries.GetClientActivityLogs
{
    public class GetClientActivityLogsQueryHandler : IRequestHandler<GetClientActivityLogsQuery, CommonResultResponseDto<IList<GetClientActivityLogsResponseDto>>>
    {
        private readonly IReportService _reportService;
        public GetClientActivityLogsQueryHandler(IReportService reportService)
        {
            _reportService = reportService;
        }

        public async Task<CommonResultResponseDto<IList<GetClientActivityLogsResponseDto>>> Handle(GetClientActivityLogsQuery getClientActivityLogsQuery, CancellationToken cancellationToken)
        {
            return await _reportService.GetClientActivityLogs(getClientActivityLogsQuery.clientId);
        }
    }
}
