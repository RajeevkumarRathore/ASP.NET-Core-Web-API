using Domain.Entities;
using DTO.Response;
using DTO.Response.Report;
using MediatR;

namespace Application.Handler.Settings.Command.SaveSummaryQuotaSettings
{
    public class SaveSummaryQuotaSettingsCommand : IRequest<CommonResultResponseDto<Setting>>
    {
        public SaveSummaryQuotaSettingsCommand()
        {
            QuotaReq = new List<QuotaEntry>();
        }
        public List<QuotaEntry> QuotaReq { get; set; }
    }
}
