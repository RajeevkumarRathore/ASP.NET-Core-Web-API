using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.Header;
using DTO.Request.ImportantNumber;
using DTO.Response;
using DTO.Response.Header;
using DTO.Response.ImportantNumber;

namespace Application.Abstraction.Services
{
    public interface IImportantNumberCategoriesService
    {
        Task<CommonResultResponseDto<List<ImportantNumberCategoriesResponseDto>>> GetAllImportantNumberCategories();
        Task<CommonResultResponseDto<List<ImportantNumbersResponseDto>>> GetImportantNumbers(ImportantNumberRequestDto importantNumberRequest);
        Task<CommonResultResponseDto<PaginatedList<GetAllCategoriesResponseDto>>> GetAllCategories(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<CommonResultResponseDto<CreateUpdateCategoryResponseDto>> CreateUpdateCategory(CreateUpdateCategoryRequestDto createUpdateCategoryRequestDto);
        Task<CommonResultResponseDto<string>> DeleteCategory(DeleteCategoryRequestDto deleteCategoryRequestDto);
        Task<CommonResultResponseDto<IList<GetAllCategoriesResponseDto>>> GetCategoryNames();
    }
}
