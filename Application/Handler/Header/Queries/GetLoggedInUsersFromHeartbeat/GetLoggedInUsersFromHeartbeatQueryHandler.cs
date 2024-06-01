using Application.Abstraction.Services;
using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.Header.Queries.GetLoggedInUsersFromHeartbeat
{
    public class GetLoggedInUsersFromHeartbeatQueryHandler : IRequestHandler<GetLoggedInUsersFromHeartbeatQuery, CommonResultResponseDto<List<UserHeartbeat>>>
    {
        private readonly IUserHeartbeatsServices  _userHeartbeatsServices;
        public GetLoggedInUsersFromHeartbeatQueryHandler(IUserHeartbeatsServices userHeartbeatsServices)
        {
            _userHeartbeatsServices = userHeartbeatsServices;
        }
        public async Task<CommonResultResponseDto<List<UserHeartbeat>>> Handle(GetLoggedInUsersFromHeartbeatQuery  getLoggedInUsersFromHeartbeatQuery, CancellationToken cancellationToken)
        {
            return await _userHeartbeatsServices.GetLoggedInUsersFromHeartbeat(getLoggedInUsersFromHeartbeatQuery.loggedInUserId);
        }
    }
}
