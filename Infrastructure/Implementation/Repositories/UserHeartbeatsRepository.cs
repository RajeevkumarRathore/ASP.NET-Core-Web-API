using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Dapper;
using Domain.Entities;
using System.Data;

namespace Infrastructure.Implementation.Repositories
{
    public class UserHeartbeatsRepository : IUserHeartbeatsRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;
        public UserHeartbeatsRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;
        }
        public async Task<List<UserHeartbeat>> GetLoggedInUsersFromHeartbeat(int loggedInUserId, DateTime lastOneMinute)
        {
            List<UserHeartbeat> usersFromHeartbeat;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync("usp_hatzalah_GetLoggedInUsersFromHeartbeat", _dbContext.GetDapperDynamicParameters(
                      _parameterManager.Get("@LoggedInUserId", loggedInUserId),
                      _parameterManager.Get("@LastOneMinute", lastOneMinute, ParameterDirection.Input, DbType.DateTime)
                    ),
                    commandType: CommandType.StoredProcedure);
                usersFromHeartbeat = result.Read<UserHeartbeat>().ToList();
                dbConnection.Close();
            }
            return usersFromHeartbeat;
        }
    }
}
