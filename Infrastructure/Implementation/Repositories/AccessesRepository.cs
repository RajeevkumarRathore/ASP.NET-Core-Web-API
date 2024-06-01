using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Application.Common.Dtos;
using Dapper;
using DTO.Request.Accesses;
using DTO.Response.Accesses;
using System.Data;

namespace Infrastructure.Implementation.Repositories
{
    public class AccessesRepository : IAccessesRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;

        public AccessesRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;

        }

        public async Task<(List<AccessesResponseDto>, int)> GetAllAccesses(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            List<AccessesResponseDto> accesses;
            int total = 0;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
            "usp_hatzalah_GetAllAccesses", _dbContext.GetDapperDynamicParameters
            (_parameterManager.Get("@StartRow", commonRequest.StartRow),
              _parameterManager.Get("@EndRow", commonRequest.EndRow),
              _parameterManager.Get("@FilterModel", filterModel),
              _parameterManager.Get("@OrderBy", getSort),
              _parameterManager.Get("@SearchText", commonRequest.SearchText)
            ),
            commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                accesses = result.Read<AccessesResponseDto>().ToList();
                dbConnection.Close();
            }
            return (accesses, total);
        }

        public async Task<bool> IsExistAccesses(string name, int id = 0)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_IsExistAccesses",
        _parameterManager.Get("@Id", id),
        _parameterManager.Get("@Name", name));
        }

        public async Task<AccessesResponseDto> GetAccessesById(int id)
        {
            return await _dbContext.ExecuteStoredProcedure<AccessesResponseDto>("usp_hatzalah_GetAccessesById",
         _parameterManager.Get("@Id", id));
        }

        public async Task<int> GetAccessesByName(string name)
        {
            return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_GetAccessesByName",
        _parameterManager.Get("@AccessesByName", name));
        }

        public async Task<int> CreateUpdateAccesses(CreateUpdateAccessesRequestDto createUpdateAccessesRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_CreateUpdateAccesses",
        _parameterManager.Get("@Id", createUpdateAccessesRequestDto.Id),
         _parameterManager.Get("@Name", createUpdateAccessesRequestDto.Name)
        );
        }

        public async Task<bool> DeleteAccess(int id)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_DeleteAccess",
         _parameterManager.Get("@Id", id));
        }
    }
}
