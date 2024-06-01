using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Application.Common.Dtos;
using Dapper;
using DTO.Request.UrgencyInfoCategories;
using DTO.Response.UrgencyInfoCategories;
using System.Data;

namespace Infrastructure.Implementation.Repositories
{
    public class UrgencyInfoCategoriesRepository: IUrgencyInfoCategoriesRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;
        public UrgencyInfoCategoriesRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;
        }


        public async Task<(List<GetAllUrgencyInfoCategoriesResponseDto>, int)> GetAllUrgencyInfoCategories(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            List<GetAllUrgencyInfoCategoriesResponseDto> urgencyInfoCategories;
            int total = 0;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
            "usp_hatzalah_GetAllUrgencyInfoCategories", _dbContext.GetDapperDynamicParameters
            (_parameterManager.Get("@StartRow", commonRequest.StartRow),
              _parameterManager.Get("@EndRow", commonRequest.EndRow),
              _parameterManager.Get("@FilterModel", filterModel),
              _parameterManager.Get("@OrderBy", getSort),
              _parameterManager.Get("@SearchText", commonRequest.SearchText)
            ),
            commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                urgencyInfoCategories = result.Read<GetAllUrgencyInfoCategoriesResponseDto>().ToList();
                dbConnection.Close();
            }
            return (urgencyInfoCategories, total);
        }

        public async Task<IList<GetUrgencyInfoCategoryResponseDto>> GetUrgencyInfoCategories()
        {
            return await _dbContext.ExecuteStoredProcedureList<GetUrgencyInfoCategoryResponseDto>("usp_hatzalah_GetUrgencyInfoCategories");
        }

        public async Task<int> CreateUpdateUrgencyInfoCategory(CreateUpdateUrgencyInfoCategoryRequestDto createUpdateUrgencyInfoCategoryRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_CreateUpdateUrgencyInfoCategory",
           _parameterManager.Get("@Id", createUpdateUrgencyInfoCategoryRequestDto.Id),
           _parameterManager.Get("@Name", createUpdateUrgencyInfoCategoryRequestDto.Name)
           );
        }

        public async Task<bool> IsExistUrgencyInfoCategory(string name, int id = 0)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_IsExistUrgencyInfoCategory",
            _parameterManager.Get("@Id", id),
            _parameterManager.Get("@Name", name));
        }

        public async Task<bool> DeleteUrgencyInfoCategory(int id)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_DeleteUrgencyInfoCategory",
         _parameterManager.Get("@Id", id));
        }
    }
}
