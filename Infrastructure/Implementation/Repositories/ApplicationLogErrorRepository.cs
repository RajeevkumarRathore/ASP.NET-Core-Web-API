using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Domain.Entities;
namespace Infrastructure.Implementation.Repositories
{
    public class ApplicationLogErrorRepository : IApplicationLogErrorRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;
        public ApplicationLogErrorRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;
        }
        public async Task<ApplicationLog> AddApplicationLogError(ApplicationLog logError)
        {
                return await _dbContext.ExecuteStoredProcedure<ApplicationLog>("usp_hatzalah_AddApplicationLogError",
           _parameterManager.Get("@Id", logError.Id),
           _parameterManager.Get("@OccuredAtClass", logError.OccuredAtClass),
           _parameterManager.Get("@OccuredAtMethod", logError.OccuredAtMethod),
           _parameterManager.Get("@Text", logError.Text),
           _parameterManager.Get("@Message", logError.Message),
           _parameterManager.Get("@Type", logError.Type));
        }

        public async Task<DispatchActionLog> AddLogDispatchAction(DispatchActionLog logError)
        {
            return await _dbContext.ExecuteStoredProcedure<DispatchActionLog>("usp_hatzalah_AddLogDispatchAction",
                       _parameterManager.Get("@UserId", logError.UserId),
                       _parameterManager.Get("@Username", logError.Username),
                       _parameterManager.Get("@LocationId", logError.Id),
                       _parameterManager.Get("@LocationName", logError.LocationName),
                       _parameterManager.Get("@Code", logError.Code),
                       _parameterManager.Get("@IsSucceeded", logError.IsSucceeded),
                       _parameterManager.Get("@LiveUrl", logError.Message),
                       _parameterManager.Get("@ResultMessage", logError.ResultMessage),
                       _parameterManager.Get("@BackUpResultMessage", logError.BackUpResultMessage),
                       _parameterManager.Get("@BackUpUrl", logError.BackUpUrl),
                       _parameterManager.Get("@ClientIp", logError.ClientIp));

        }
    }
}
