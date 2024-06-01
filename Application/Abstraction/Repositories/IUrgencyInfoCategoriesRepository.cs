using Application.Common.Dtos;
using DTO.Request.UrgencyInfoCategories;
using DTO.Response.UrgencyInfoCategories;

namespace Application.Abstraction.Repositories
{
    public interface IUrgencyInfoCategoriesRepository
    {
        Task<(List<GetAllUrgencyInfoCategoriesResponseDto>, int)> GetAllUrgencyInfoCategories(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<int> CreateUpdateUrgencyInfoCategory(CreateUpdateUrgencyInfoCategoryRequestDto createUpdateUrgencyInfoCategoryRequestDto);
        Task<IList<GetUrgencyInfoCategoryResponseDto>> GetUrgencyInfoCategories();
        Task<bool> DeleteUrgencyInfoCategory(int id);
        Task<bool> IsExistUrgencyInfoCategory(string name, int id = 0);
    }
}
