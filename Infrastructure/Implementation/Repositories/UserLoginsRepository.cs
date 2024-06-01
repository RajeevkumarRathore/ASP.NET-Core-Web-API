using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Application.Common.Dtos;
using Dapper;
using DTO.Request.UserLogins;
using DTO.Response.UserLogins;
using System.Data;

namespace Infrastructure.Implementation.Repositories
{
    public class UserLoginsRepository : IUserLoginsRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;

        public UserLoginsRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;

        }
        public async Task<(List<UserLoginsResponseDto>, int)> GetAllUserLogins(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            List<UserLoginsResponseDto> userLogins;
            int total = 0;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
            "usp_hatzalah_GetAllUserLogins", _dbContext.GetDapperDynamicParameters
            (_parameterManager.Get("@StartRow", commonRequest.StartRow),
              _parameterManager.Get("@EndRow", commonRequest.EndRow),
              _parameterManager.Get("@FilterModel", filterModel),
              _parameterManager.Get("@OrderBy", getSort),
              _parameterManager.Get("@SearchText", commonRequest.SearchText)
            ),
            commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                userLogins = result.Read<UserLoginsResponseDto>().ToList();
                dbConnection.Close();
            }
            return (userLogins, total);
        }

        public async Task<IList<GetUserLoginByNameAndTypeResponseDto>> GetUserLoginByNameAndType(GetUserLoginByNameAndTypeRequestDto getUserLoginByNameAndTypeRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedureList<GetUserLoginByNameAndTypeResponseDto>("usp_hatzalah_GetUserLoginByNameAndType",
          _parameterManager.Get("@UserName", getUserLoginByNameAndTypeRequestDto.UserName)        
          );
        }
    }
}
