using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using DTO.Response.DailyReportRecipient;
using DTO.Request.DailyReportRecipient;

namespace Application.Abstraction.Services
{
    public interface IDailyReportRecipientService
    {
        Task<CommonResultResponseDto<PaginatedList<GetAllDailyReportRecipientResponseDto>>> GetAllDailyReportRecipient(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<CommonResultResponseDto<CreateUpdateDailyReportRecipientResponseDto>> CreateUpdateDailyReportRecipient(CreateUpdateDailyReportRecipientRequestDto createUpdateDailyReportRecipientRequestDto);
        Task<CommonResultResponseDto<string>> DeleteDailyReportRecipient(DeleteDailyReportRecipientRequestDto deleteDailyReportRecipientRequestDto);
    }
}
