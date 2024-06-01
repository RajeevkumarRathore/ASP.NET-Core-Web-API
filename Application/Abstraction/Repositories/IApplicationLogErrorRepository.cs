using Domain.Entities;
namespace Application.Abstraction.Repositories
{
    public interface IApplicationLogErrorRepository 
    {
        Task<ApplicationLog> AddApplicationLogError(ApplicationLog logError);
        Task<DispatchActionLog> AddLogDispatchAction(DispatchActionLog logError);
    }
}
