using Domain.Entities;
using DTO.Response;
namespace Application.Abstraction.Services
{
    public interface IUserHeartbeatsServices
    {
        Task<CommonResultResponseDto<List<UserHeartbeat>>> GetLoggedInUsersFromHeartbeat(int loggedInUserId);
    }
}
