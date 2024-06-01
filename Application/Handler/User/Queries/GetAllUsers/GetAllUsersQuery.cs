using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using DTO.Response.User;
using MediatR;

namespace Application.Handler.User.Queries.GetAllUsers
{
    public class GetAllUsersQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<GetUserResponseDto>>>
    {
        public ServerRowsRequest CommonRequest { get; set; }
    }
}
