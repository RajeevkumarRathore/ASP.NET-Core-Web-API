using DTO.Response.Report;

namespace DTO.Request.Settings
{
    public class SaveSummaryQuotaSettingRequestDto
    {
        public SaveSummaryQuotaSettingRequestDto()
        {
            QuotaReq =new List<QuotaEntry>();
        }
        public List<QuotaEntry> QuotaReq { get; set; }
    }
}
