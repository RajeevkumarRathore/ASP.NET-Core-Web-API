using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.UrgencyInfoCategories;
using DTO.Response;
using DTO.Response.UrgencyInfoCategories;

namespace Application.Abstraction.Services
{
    public interface IUrgencyInfoCategoriesService
    {
        Task<CommonResultResponseDto<PaginatedList<GetAllUrgencyInfoCategoriesResponseDto>>> GetAllUrgencyInfoCategories(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<CommonResultResponseDto<CreateUpdateUrgencyInfoCategoryResponseDto>> CreateUpdateUrgencyInfoCategory(CreateUpdateUrgencyInfoCategoryRequestDto createUpdateUrgencyInfoCategoryRequestDto);
        Task<CommonResultResponseDto<IList<GetUrgencyInfoCategoryResponseDto>>> GetUrgencyInfoCategories();
        Task<CommonResultResponseDto<string>> DeleteUrgencyInfoCategory(int id);
    }
}
