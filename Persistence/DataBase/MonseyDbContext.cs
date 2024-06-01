using Application.Abstraction.DataBase;
using Application.Common.Helpers;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Persistence.DataBase
{
    public class MonseyDbContext : IDbContext
    {
        private readonly string _connectionString;
        public MonseyDbContext(IConfiguration configuration)
        {
           var agency= configuration["Agencies"];
            if (agency == ConstantAgencies.Test)
            {
                _connectionString = configuration.GetConnectionString("MonseyConnection");
            }
            else if (agency == ConstantAgencies.CentralJersey)
            {
                _connectionString = configuration.GetConnectionString("CentralJersyConnection");
            }
            else if (agency == ConstantAgencies.Kiryasjoel)
            {
                _connectionString = configuration.GetConnectionString("KiryasjoelConnection");
            }
            else
            {
                _connectionString = configuration.GetConnectionString("DefaultConnection");
            }
        }

        public async Task<TEntity> ExecuteStoredProcedure<TEntity>(string storedProcedureName, params object[] parameters)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var entity = await db.QueryAsync<TEntity>(storedProcedureName, GetDapperDynamicParameters(parameters), commandType: CommandType.StoredProcedure, commandTimeout: 0);
            db.Close();
            return entity.FirstOrDefault();
        }

        public async Task<IList<TEntity>> ExecuteStoredProcedureList<TEntity>(string storedProcedureName, params object[] parameters )
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var entities = await db.QueryAsync<TEntity>(storedProcedureName, GetDapperDynamicParameters(parameters), commandType: CommandType.StoredProcedure, commandTimeout: 0);            
            db.Close();
            return entities.ToList();
        }

        public async Task<IList<TEntity>> ExecuteStoredProcedureList<TEntity>(string storedProcedureName)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var entities = await db.QueryAsync<TEntity>(storedProcedureName, null, commandType: CommandType.StoredProcedure, commandTimeout: 0);
            db.Close();
            return entities.ToList();
        }

        public async Task<bool> ExecuteStoredProcedure(string storedProcedureName, params object[] parameters)
        {
            bool isRecordInserted = false;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                await db.QueryAsync(storedProcedureName, GetDapperDynamicParameters(parameters), commandType: CommandType.StoredProcedure, commandTimeout: 0);
                isRecordInserted = true;
            }
            return isRecordInserted;
        }
        public DynamicParameters GetDapperDynamicParameters(params object[] parameters)
        {
            var dynamicParams = new DynamicParameters();
            for (int index = 0; index <= parameters.Length - 1; index++)
            {
                var item = ((SqlParameter)parameters[index]);
                dynamicParams.Add(item.ParameterName, item.Value, item.DbType, item.Direction);
            }
            return dynamicParams;
        }
        public IDbConnection GetDbConnection()
        {
            return new SqlConnection(_connectionString);
        }

       
    }
}
