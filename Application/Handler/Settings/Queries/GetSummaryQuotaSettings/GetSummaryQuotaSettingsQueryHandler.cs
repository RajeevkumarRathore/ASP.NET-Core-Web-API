using DTO.Response;
using MediatR;
using Application.Abstraction.Services;
using DTO.Response.Report;

namespace Application.Handler.Settings.Queries.GetSummaryQuotaSettings
{
    public class GetSummaryQuotaSettingsQueryHandler : IRequestHandler<GetSummaryQuotaSettingsQuery, CommonResultResponseDto<List<QuotaEntry>>>
    {
        private readonly ISettingsService _settingsService;
        public GetSummaryQuotaSettingsQueryHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<List<QuotaEntry>>> Handle(GetSummaryQuotaSettingsQuery request, CancellationToken cancellationToken)
        {
            return await _settingsService.GetSummaryQuotaSettings();
        }
    }
}
