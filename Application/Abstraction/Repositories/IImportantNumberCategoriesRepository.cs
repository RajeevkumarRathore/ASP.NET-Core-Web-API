using Application.Common.Dtos;
using DTO.Request.Header;
using DTO.Request.ImportantNumber;
using DTO.Response.Header;
using DTO.Response.ImportantNumber;

namespace Application.Abstraction.Repositories
{
    public interface IImportantNumberCategoriesRepository
    {
        Task<List<ImportantNumbersResponseDto>> GetImportantNumbers(ImportantNumberRequestDto importantNumberRequest);
        Task<List<ImportantNumberCategoriesResponseDto>> GetAllImportantNumberCategories();
        Task<List<ImportantNumbersDto>> FetchImportantNumbers(ImportantNumberRequestDto importantNumberRequest);
        Task<(List<GetAllCategoriesResponseDto>, int)> GetAllCategories(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<int> CreateUpdateCategory(CreateUpdateCategoryRequestDto createUpdateCategoryRequestDto);
        Task<bool> IsExistCategoryName(string name, int id = 0);
        Task<bool> DeleteCategory(DeleteCategoryRequestDto deleteCategoryRequestDto);
        Task<IList<GetAllCategoriesResponseDto>> GetCategoryNames();
    }
}
