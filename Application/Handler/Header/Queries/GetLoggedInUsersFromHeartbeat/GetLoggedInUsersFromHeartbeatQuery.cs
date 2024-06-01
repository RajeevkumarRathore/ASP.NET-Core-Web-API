using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.Header.Queries.GetLoggedInUsersFromHeartbeat
{
    public class GetLoggedInUsersFromHeartbeatQuery : IRequest<CommonResultResponseDto<List<UserHeartbeat>>>
    {
        public int loggedInUserId { get; set; }
    }
}
