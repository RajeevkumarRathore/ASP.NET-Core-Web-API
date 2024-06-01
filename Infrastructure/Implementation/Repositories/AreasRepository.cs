using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Application.Common.Dtos;
using Dapper;
using DTO.Request.Areas;
using DTO.Response.Areas;
using System.Data;

namespace Infrastructure.Implementation.Repositories
{
    public class AreasRepository : IAreasRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;

        public AreasRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;

        }

        public async Task<int> CreateUpdateAreas(CreateUpdateAreasRequestDto createUpdateAreasRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_CreateUpdateAreas",
            _parameterManager.Get("@Id", createUpdateAreasRequestDto.Id),
            _parameterManager.Get("@AreaName", createUpdateAreasRequestDto.AreaName),
            _parameterManager.Get("@ZipCode", createUpdateAreasRequestDto.ZipCode),
            _parameterManager.Get("@CityName", createUpdateAreasRequestDto.CityName),
            _parameterManager.Get("@FireDistrict", createUpdateAreasRequestDto.FireDistrict)
            );
        }

        public async Task<bool> DeleteAreas(DeleteAreasRequestDto deleteAreasRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_DeleteAreas",
           _parameterManager.Get("@Id", deleteAreasRequestDto.Id));
        }

        public async Task<(List<GetAllAreasResponseDto>, int)> GetAllAreas(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            List<GetAllAreasResponseDto> areas;
            int total = 0;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
            "usp_hatzalah_GetAllAreas", _dbContext.GetDapperDynamicParameters
            (_parameterManager.Get("@StartRow", commonRequest.StartRow),
              _parameterManager.Get("@EndRow", commonRequest.EndRow),
              _parameterManager.Get("@FilterModel", filterModel),
              _parameterManager.Get("@OrderBy", getSort),
              _parameterManager.Get("@SearchText", commonRequest.SearchText)
            ),
            commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                areas = result.Read<GetAllAreasResponseDto>().ToList();
                dbConnection.Close();
            }
            return (areas, total);
        }

        public async Task<IList<GetAreasResponseDto>> GetAreas()
        {
            return await _dbContext.ExecuteStoredProcedureList<GetAreasResponseDto>("usp_hatzalah_GetAreas");
        }

        public async  Task<bool> IsExistStreetArea(string name, int id = 0)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_IsExistArea",
             _parameterManager.Get("@Id", id),
           _parameterManager.Get("@Name", name));
        }
      
    }
}
