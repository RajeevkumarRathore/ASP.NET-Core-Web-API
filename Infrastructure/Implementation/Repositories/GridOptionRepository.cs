using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Dapper;
using DTO.Request.GridOption;
using System.Data;


namespace Infrastructure.Implementation.Repositories
{
    public class GridOptionRepository : IGridOptionRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;
        public GridOptionRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;
        }

        public async Task<IList<GridOptionRequestDto>> GetAllColumnStatesByUserId(int UserId)
        {
            return await _dbContext.ExecuteStoredProcedureList<GridOptionRequestDto>("usp_hatzalah_GetAllColumnStatesByUserId",
                 _parameterManager.Get("@UserId", UserId));
        }

        public async Task<string> UpsertColumnState(GridOptionRequestDto gridOptionRequestDto)
        {
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var parameters = _dbContext.GetDapperDynamicParameters(
               _parameterManager.Get("@UserId", gridOptionRequestDto.UserId),
               _parameterManager.Get("@GridId", gridOptionRequestDto.GridId),
               _parameterManager.Get("@ColumnState", gridOptionRequestDto.ColumnState));


                parameters.Add("@ResultMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);

                var result = await dbConnection.QueryMultipleAsync(
                    "usp_hatzalah_UpsertColumnState", parameters, commandType: CommandType.StoredProcedure);

                var resultMessage = parameters.Get<string>("@ResultMessage");

                dbConnection.Close();
                return resultMessage;

            }
        }
    }
}
