using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.Report;
using MediatR;

namespace Application.Handler.Reports.Queries.GetCallHistoryDetail
{
    public class GetCallHistoryDetailQueryHandler : IRequestHandler<GetCallHistoryDetailQuery, CommonResultResponseDto<GetCallHistoryDetailResponseDto>>
    {
        private readonly IReportService _reportService;
        public GetCallHistoryDetailQueryHandler(IReportService reportService )
        {
            _reportService = reportService;
        }
        public async Task<CommonResultResponseDto<GetCallHistoryDetailResponseDto>> Handle(GetCallHistoryDetailQuery getCallHistoryDetailQuery, CancellationToken cancellationToken)
        {
            return await _reportService.GetCallHistoryDetail(getCallHistoryDetailQuery.ClientId);
        }
    }
}
