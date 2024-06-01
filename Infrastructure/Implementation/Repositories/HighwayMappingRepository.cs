using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Application.Common.Dtos;
using Dapper;
using DTO.Request.HighwayMapping;
using DTO.Response.HighwayMapping;
using System.Data;

namespace Infrastructure.Implementation.Repositories
{
    public class HighwayMappingRepository :IHighwayMappingRepository
    {
       
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;
        public HighwayMappingRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;
        }

        public async Task<int> CreateUpdateHighwayMapping(CreateUpdateHighwayMappingRequestDto createUpdateHighwayMappingRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_CreateUpdateHighwayMapping",
       _parameterManager.Get("@Id", createUpdateHighwayMappingRequestDto.Id),
       _parameterManager.Get("@Name", createUpdateHighwayMappingRequestDto.Name),
       _parameterManager.Get("@Latitude", createUpdateHighwayMappingRequestDto.Latitude),
       _parameterManager.Get("@Longitude", createUpdateHighwayMappingRequestDto.Longitude),
       _parameterManager.Get("@IsMilemark", createUpdateHighwayMappingRequestDto.IsMilemark),
       _parameterManager.Get("@IsExit", createUpdateHighwayMappingRequestDto.IsExit),
       _parameterManager.Get("@RelatedHighway", createUpdateHighwayMappingRequestDto.RelatedHighway));
        }

        public async Task<bool> DeleteHighwayMapping(DeleteHighwayMappingRequestDto deleteHighwayMappingRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_DeleteHighwayMapping",
            _parameterManager.Get("@Id", deleteHighwayMappingRequestDto.Id));
        }

        public async Task<(List<GetAllHighwayMappingResponseDto>, int)> GetAllHighwayMapping(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            List<GetAllHighwayMappingResponseDto> highway;
            int total = 0;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
            "usp_hatzalah_GetAllHighwayMapping", _dbContext.GetDapperDynamicParameters
            (_parameterManager.Get("@StartRow", commonRequest.StartRow),
              _parameterManager.Get("@EndRow", commonRequest.EndRow),
              _parameterManager.Get("@FilterModel", filterModel),
              _parameterManager.Get("@OrderBy", getSort),
              _parameterManager.Get("@SearchText", commonRequest.SearchText)
            ),
            commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                highway = result.Read<GetAllHighwayMappingResponseDto>().ToList();
                dbConnection.Close();
            }
            return (highway, total);
        }

        public async Task<IList<GetAllHighwayNameResponseDto>> GetAllHighwayName()
        {
            return await _dbContext.ExecuteStoredProcedureList<GetAllHighwayNameResponseDto>("usp_hatzalah_GetAllHighwayName");
        }

        public async Task<bool> IsExistHighwayMapping(string name, int id = 0)
        {

            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_IsExistHighwayMapping",
               _parameterManager.Get("@Id", id),
             _parameterManager.Get("@Name", name));
        }
    }
}
