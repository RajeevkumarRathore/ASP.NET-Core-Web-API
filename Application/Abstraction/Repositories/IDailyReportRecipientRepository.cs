using Application.Common.Dtos;
using DTO.Request.DailyReportRecipient;
using DTO.Response.DailyReportRecipient;

namespace Application.Abstraction.Repositories
{
    public interface IDailyReportRecipientRepository
    {
        Task<(List<GetAllDailyReportRecipientResponseDto>, int)> GetAllDailyReportRecipient(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<int> CreateUpdateDailyReportRecipient(CreateUpdateDailyReportRecipientRequestDto createUpdateDailyReportRecipientRequestDto);
        Task<bool> DeleteDailyReportRecipient(DeleteDailyReportRecipientRequestDto deleteDailyReportRecipientRequestDto);
        Task<bool> IsExistDailyReportRecipient(string name, int id = 0);
    }
}
