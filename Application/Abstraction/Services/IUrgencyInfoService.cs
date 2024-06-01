using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.UrgencyInfo;
using DTO.Response;
using DTO.Response.UrgencyInfo;

namespace Application.Abstraction.Services
{
    public interface IUrgencyInfoService
    {
        Task<CommonResultResponseDto<PaginatedList<UrgencyInfoResponseDto>>> GetAllUrgencyInfo(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<CommonResultResponseDto<CreateUpdateUrgencyInfoResponseDto>> CreateUpdateUrgencyInfo(CreateUpdateUrgencyInfoRequestDto createUpdateUrgencyInfoRequestDto);
        Task<CommonResultResponseDto<string>> DeleteUrgencyInfo(int id);
    }
}
