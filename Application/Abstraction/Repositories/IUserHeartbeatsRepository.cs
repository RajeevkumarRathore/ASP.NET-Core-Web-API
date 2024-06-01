using Domain.Entities;
namespace Application.Abstraction.Repositories
{
    public interface IUserHeartbeatsRepository 
    {
        Task<List<UserHeartbeat>> GetLoggedInUsersFromHeartbeat(int loggedInUserId, DateTime lastOneMinute);
    }
}
