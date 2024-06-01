using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Application.Common.Dtos;
using Dapper;
using DTO.Request.Header;
using DTO.Request.ImportantNumber;
using DTO.Response.Header;
using DTO.Response.ImportantNumber;
using System.Data;

namespace Infrastructure.Implementation.Repositories
{
    public class ImportantNumberCategoriesRepository : IImportantNumberCategoriesRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;

        public ImportantNumberCategoriesRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;

        }

        public async Task<List<ImportantNumbersDto>> FetchImportantNumbers(ImportantNumberRequestDto importantNumberRequest)
        {
            List<ImportantNumbersDto> allImportantNumbers;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync("usp_hatzalah_GetImportantNumbersByCategoryAlert", _dbContext.GetDapperDynamicParameters(
                _parameterManager.Get("@Search_text", importantNumberRequest.filter),
                _parameterManager.Get("@Category", importantNumberRequest.category),
                _parameterManager.Get("@fromAlert", importantNumberRequest.fromAlert)),
                    commandType: CommandType.StoredProcedure);
                allImportantNumbers = result.Read<ImportantNumbersDto>().ToList();
                dbConnection.Close();
            }
            return (allImportantNumbers);
        }

        public async Task<List<ImportantNumberCategoriesResponseDto>> GetAllImportantNumberCategories()
        {
            List<ImportantNumberCategoriesResponseDto> allImportantNumber;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync("usp_hatzalah_GetAllImportantNumberCategories", _dbContext.GetDapperDynamicParameters(

                    ),
                    commandType: CommandType.StoredProcedure);
                allImportantNumber = result.Read<ImportantNumberCategoriesResponseDto>().ToList();
                dbConnection.Close();
            }
            return allImportantNumber;
        }

        public async Task<List<ImportantNumbersResponseDto>> GetImportantNumbers(ImportantNumberRequestDto importantNumberRequest)
        {
            List<ImportantNumbersResponseDto> allImportantNumbers;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync("usp_hatzalah_GetImportantNumbers", _dbContext.GetDapperDynamicParameters(
                _parameterManager.Get("@SearchText", importantNumberRequest.filter),
                _parameterManager.Get("@Category", importantNumberRequest.category)),
                    commandType: CommandType.StoredProcedure);
                allImportantNumbers = result.Read<ImportantNumbersResponseDto>().ToList();
                dbConnection.Close();
            }
            return (allImportantNumbers);
        }
        public async Task<(List<GetAllCategoriesResponseDto>, int)> GetAllCategories(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            List<GetAllCategoriesResponseDto> numbers;
            int total = 0;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
            "usp_hatzalah_GetAllCategories", _dbContext.GetDapperDynamicParameters
            (_parameterManager.Get("@StartRow", commonRequest.StartRow),
              _parameterManager.Get("@EndRow", commonRequest.EndRow),
              _parameterManager.Get("@FilterModel", filterModel),
              _parameterManager.Get("@OrderBy", getSort),
              _parameterManager.Get("@SearchText", commonRequest.SearchText)
            ),
            commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                numbers = result.Read<GetAllCategoriesResponseDto>().ToList();
                dbConnection.Close();
            }
            return (numbers, total);
        }
        public async Task<int> CreateUpdateCategory(CreateUpdateCategoryRequestDto createUpdateCategoryRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_CreateUpdateCategory",
             _parameterManager.Get("@Id", createUpdateCategoryRequestDto.Id),
             _parameterManager.Get("@Name", createUpdateCategoryRequestDto.Name));
        }

        public async Task<bool> IsExistCategoryName(string name, int id = 0)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_IsExistCategoryName",
              _parameterManager.Get("@Id", id),
              _parameterManager.Get("@Name", name));
        }
        public async Task<bool> DeleteCategory(DeleteCategoryRequestDto deleteCategoryRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_DeleteCategory",
            _parameterManager.Get("@Id", deleteCategoryRequestDto.Id));
        }

        public async Task<IList<GetAllCategoriesResponseDto>> GetCategoryNames()
        {
            return await _dbContext.ExecuteStoredProcedureList<GetAllCategoriesResponseDto>("usp_hatzalah_GetCategoryNames");
        }
    }
}
