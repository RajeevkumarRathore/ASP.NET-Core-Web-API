using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Application.Common.Dtos;
using Dapper;
using DTO.Request.UrgentNumber;
using DTO.Response.UrgentNumber;
using System.Data;

namespace Infrastructure.Implementation.Repositories
{
    public class UrgentNumberRepository : IUrgentNumberRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;
        public UrgentNumberRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;
        }

        public  async Task<int> CreateUpdateUrgentNumber(CreateUpdateUrgentNumberRequestDto createUpdateUrgentNumberRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_CreateUpdateUrgentNumber",
             _parameterManager.Get("@Id", createUpdateUrgentNumberRequestDto.Id),
              _parameterManager.Get("@Firstname", createUpdateUrgentNumberRequestDto.Firstname),
              _parameterManager.Get("@Lastname", createUpdateUrgentNumberRequestDto.Lastname),
              _parameterManager.Get("@Phone", createUpdateUrgentNumberRequestDto.Phone),
              _parameterManager.Get("@CreatedBy", createUpdateUrgentNumberRequestDto.CreatedBy),
              _parameterManager.Get("@UpdatedBy", createUpdateUrgentNumberRequestDto.UpdatedBy));
        }

        public async Task<bool> DeleteUrgentNumber(int id)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_DeleteUrgentNumber",
          _parameterManager.Get("@Id", id));
        }

        public async Task<(List<GetUrgentNumberResponseDto>, int)> GetUrgentNumber(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            List<GetUrgentNumberResponseDto> urgentNumber;
            int total = 0;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
            "usp_hatzalah_GetUrgentNumber", _dbContext.GetDapperDynamicParameters
            (_parameterManager.Get("@StartRow", commonRequest.StartRow),
              _parameterManager.Get("@EndRow", commonRequest.EndRow),
              _parameterManager.Get("@FilterModel", filterModel),
              _parameterManager.Get("@OrderBy", getSort),
              _parameterManager.Get("@SearchText", commonRequest.SearchText)
            ),
            commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                urgentNumber = result.Read<GetUrgentNumberResponseDto>().ToList();
                dbConnection.Close();
            }
            return (urgentNumber, total);
        }

        public async Task<bool> IsExistUrgentNumber(string name, int id = 0)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_IsExistUrgentNumber",
             _parameterManager.Get("@Id", id),
             _parameterManager.Get("@Name", name));
        }
    }
}
