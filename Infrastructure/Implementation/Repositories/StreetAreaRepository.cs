using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Application.Common.Dtos;
using Dapper;
using DTO.Request.StreetArea;
using DTO.Response.StreetArea;
using System.Data;

namespace Infrastructure.Implementation.Repositories
{
    public class StreetAreaRepository : IStreetAreaRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;

  

        public StreetAreaRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;

        }

        public async  Task<int> CreateUpdateStreetArea(CreateUpdateStreetAreaRequestDto createUpdateStreetAreaRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_CreateUpdateStreetArea",
           _parameterManager.Get("@Id", createUpdateStreetAreaRequestDto.Id),
           _parameterManager.Get("@StreetName", createUpdateStreetAreaRequestDto.StreetName),
           _parameterManager.Get("@AreaName", createUpdateStreetAreaRequestDto.AreaName),
           _parameterManager.Get("@CityName", createUpdateStreetAreaRequestDto.CityName),
           _parameterManager.Get("@Zip", createUpdateStreetAreaRequestDto.Zip),
           _parameterManager.Get("@StreetNumber", createUpdateStreetAreaRequestDto.StreetNumber));

        }

        public async  Task<bool> DeleteStreetArea(DeleteStreetAreaRequestDto deleteStreetAreaRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_DeleteStreetArea",
           _parameterManager.Get("@Id", deleteStreetAreaRequestDto.Id));
        }

        public async Task<(List<GetAllStreetAreaResponseDto>, int)> GetAllStreetArea(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            List<GetAllStreetAreaResponseDto> steetareas;
            int total = 0;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
            "usp_hatzalah_GetAllStreetArea", _dbContext.GetDapperDynamicParameters
            (_parameterManager.Get("@StartRow", commonRequest.StartRow),
              _parameterManager.Get("@EndRow", commonRequest.EndRow),
              _parameterManager.Get("@FilterModel", filterModel),
              _parameterManager.Get("@OrderBy", getSort),
              _parameterManager.Get("@SearchText", commonRequest.SearchText)
            ),
            commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                steetareas = result.Read<GetAllStreetAreaResponseDto>().ToList();
                dbConnection.Close();
            }
            return (steetareas, total);
        }

        public async Task<bool> IsExistStreetArea(string Name, int id = 0)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_IsExistStreetArea",
              _parameterManager.Get("@Id", id),
              _parameterManager.Get("@Name", Name));
        }
  

    }
}
