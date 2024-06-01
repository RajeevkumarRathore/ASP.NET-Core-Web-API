using Application.Abstraction.Services;
using DTO.Request.Report;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Reports.Command.UpdateNightCallTimesSetting
{
    public class UpdateNightCallTimesSettingQueryHandler : IRequestHandler<UpdateNightCallTimesSettingQuery, CommonResultResponseDto<UpdateNightCallTimesSettingRequestDto>>
    {
        private readonly IReportService _reportService;
        public UpdateNightCallTimesSettingQueryHandler(IReportService reportService)
        {
            _reportService = reportService;   
        }

        public async Task<CommonResultResponseDto<UpdateNightCallTimesSettingRequestDto>> Handle(UpdateNightCallTimesSettingQuery updateNightCallTimesSettingQuery, CancellationToken cancellationToken)
        {
            return await _reportService.UpdateNightCallTimesSettings(updateNightCallTimesSettingQuery.Adapt<UpdateNightCallTimesSettingRequestDto>());
        }
    }
}
