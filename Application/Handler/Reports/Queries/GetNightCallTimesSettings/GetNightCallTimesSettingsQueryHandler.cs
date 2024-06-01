using Application.Abstraction.Services;
using DTO.Request.Report;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Reports.Queries.GetNightCallTimesSettings
{
    public class GetNightCallTimesSettingsQueryHandler : IRequestHandler<GetNightCallTimesSettingsQuery, CommonResultResponseDto<GetNightCallTimesSettingsRequestDto>>
    {
        private readonly IReportService _reportService;
        public GetNightCallTimesSettingsQueryHandler(IReportService reportService)
        {
                _reportService = reportService;
        }
        public async Task<CommonResultResponseDto<GetNightCallTimesSettingsRequestDto>> Handle(GetNightCallTimesSettingsQuery  getNightCallTimesSettingsQuery, CancellationToken cancellationToken)
        {
            return await _reportService.GetNightCallTimesSettings(getNightCallTimesSettingsQuery.Adapt<GetNightCallTimesSettingsRequestDto>());
        }
    }
}
