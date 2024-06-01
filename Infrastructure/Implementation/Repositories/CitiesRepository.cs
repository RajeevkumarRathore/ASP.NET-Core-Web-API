using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Application.Common.Dtos;
using Dapper;
using DTO.Request.Cities;
using DTO.Response.Cities;
using System.Data;

namespace Infrastructure.Implementation.Repositories
{
    public class CitiesRepository : ICitiesRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;

  

        public CitiesRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;

        }

        public async Task<int> CreateUpdateCities(CreateUpdateCitiesRequestDto createUpdateCitiesRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_CreateUpdateCities",
           _parameterManager.Get("@Id", createUpdateCitiesRequestDto.Id),
           _parameterManager.Get("@CityName", createUpdateCitiesRequestDto.CityName));
          
        }

        public async Task<bool> DeleteCities(DeleteCitiesRequestDto deleteCitiesRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_DeleteCities",
           _parameterManager.Get("@Id", deleteCitiesRequestDto.Id));
        }

        public async Task<(List<GetAllCitiesResponseDto>, int)> GetAllCities(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            List<GetAllCitiesResponseDto> cities;
            int total = 0;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
            "usp_hatzalah_GetAllCities", _dbContext.GetDapperDynamicParameters
            (_parameterManager.Get("@StartRow", commonRequest.StartRow),
              _parameterManager.Get("@EndRow", commonRequest.EndRow),
              _parameterManager.Get("@FilterModel", filterModel),
              _parameterManager.Get("@OrderBy", getSort),
              _parameterManager.Get("@SearchText", commonRequest.SearchText)
            ),
            commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                cities = result.Read<GetAllCitiesResponseDto>().ToList();
                dbConnection.Close();
            }
            return (cities, total);
        }

        public  async Task<IList<GetCitiesResponseDto>> GetCities()
        {
            return await _dbContext.ExecuteStoredProcedureList<GetCitiesResponseDto>("usp_hatzalah_GetCities");
        }

        public async Task<bool> IsExistCity(string name, int id = 0)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_IsExistCity",
              _parameterManager.Get("@Id", id),
            _parameterManager.Get("@Name", name));
        }

    }
}
