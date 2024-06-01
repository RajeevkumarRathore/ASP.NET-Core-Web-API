using Application.Common.Dtos;
using DTO.Request.UrgencyInfo;
using DTO.Response.UrgencyInfo;

namespace Application.Abstraction.Repositories
{
    public interface IUrgencyInfoRepository
    {
        Task<(List<UrgencyInfoResponseDto>, int)> GetAllUrgencyInfo(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<int> CreateUpdateUrgencyInfo(CreateUpdateUrgencyInfoRequestDto createUpdateUrgencyInfoRequestDto);
        Task<bool> DeleteUrgencyInfo(int id);
        Task<bool> IsExistUrgencyInfo(string name, int id = 0);
    }
}
