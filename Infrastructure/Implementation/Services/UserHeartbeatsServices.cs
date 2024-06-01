using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Domain.Entities;
using DTO.Response;
using Helper;

namespace Infrastructure.Implementation.Services
{
    public class UserHeartbeatsServices : IUserHeartbeatsServices
    {
        private readonly IUserHeartbeatsRepository _userHeartbeatsRepository;
        public UserHeartbeatsServices(IUserHeartbeatsRepository userHeartbeatsRepository)
        {
            _userHeartbeatsRepository = userHeartbeatsRepository;
        }
        public async Task<CommonResultResponseDto<List<UserHeartbeat>>> GetLoggedInUsersFromHeartbeat(int loggedInUserId)
        {
            DateTime lastOneMinute = DateTime.Now.AddMinutes(-1);

            var usersFromHeartbeat = await _userHeartbeatsRepository.GetLoggedInUsersFromHeartbeat(loggedInUserId, lastOneMinute);
            return CommonResultResponseDto<List<UserHeartbeat>>.Success(new string[] { ActionStatusHelper.Success }, usersFromHeartbeat);
        }
    }
}
