using DTO.Response;
using MediatR;
using DTO.Response.Report;

namespace Application.Handler.Settings.Queries.GetSummaryQuotaSettings
{
    public class GetSummaryQuotaSettingsQuery : IRequest<CommonResultResponseDto<List<QuotaEntry>>>
    {
    }
}
