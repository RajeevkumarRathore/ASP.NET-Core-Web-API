using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Application.Handler.Header.Dtos;
using Dapper;
using Domain.Entities;
using DTO.Response.Header;
using System.Data;


namespace Infrastructure.Implementation.Repositories
{
    public class DispatcherNotificationsRepository : IDispatcherNotificationsRepository   
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;
        public DispatcherNotificationsRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;
        }
        public async Task<List<DispatchNotificationResponseDto>> GetEffectiveDispatchNotifications()
        {
            List<DispatchNotificationResponseDto> effectiveDispatch;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync("usp_hatzalah_GetEffectiveDispatchNotifications", _dbContext.GetDapperDynamicParameters(),
                    commandType: CommandType.StoredProcedure);
                effectiveDispatch = result.Read<DispatchNotificationResponseDto>().ToList();
                dbConnection.Close();
            }
            return effectiveDispatch;
        }
        public async Task<DispatcherNotification> SaveDispatchNotification(DispatcherNotification dispatcherNotification)
        {
            return await _dbContext.ExecuteStoredProcedure<DispatcherNotification>("usp_hatzalah_SaveDispatchNotification",
           _parameterManager.Get("@CreatedById", dispatcherNotification.CreatedById),
           _parameterManager.Get("@DaySelect", dispatcherNotification.DaySelect),
           _parameterManager.Get("@EffectiveUntill", dispatcherNotification.EffectiveUntillDate, ParameterDirection.Input, DbType.DateTime2),
           _parameterManager.Get("@Text", dispatcherNotification.Text),
           _parameterManager.Get("@RelatedPlaceId", dispatcherNotification.RelatedPlaceId ?? 0));

        }
        public async Task<bool> DeleteDispatchNotification(int dispatchNotificationId)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_DeleteDispatchNotification",
          _parameterManager.Get("@Id", dispatchNotificationId));
        }

        public async Task<CanSendNotificationsPermissionDto> CheckIfUserCanSendNotifications(int userId, string canSendNotifications)
        {
            return await _dbContext.ExecuteStoredProcedure<CanSendNotificationsPermissionDto>("usp_hatzalah_CheckIfUserCanSendNotifications",
            _parameterManager.Get("@UserId", userId),
            _parameterManager.Get("@CanSendNotifications", canSendNotifications));
        }

        public async Task<DispatchNotificationDto> GetDispatchNotification(int id)
        {
            return await _dbContext.ExecuteStoredProcedure<DispatchNotificationDto>("usp_hatzalah_GetDispatchNotification",
            _parameterManager.Get("@NotificationId", id));
        }

     

    }
}
