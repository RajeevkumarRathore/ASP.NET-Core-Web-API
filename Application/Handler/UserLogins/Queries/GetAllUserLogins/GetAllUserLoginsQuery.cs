using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using DTO.Response.UserLogins;
using MediatR;

namespace Application.Handler.UserLogins.Queries.GetAllUserLogins
{
    public class GetAllUserLoginsQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<UserLoginsResponseDto>>>
    {
        public ServerRowsRequest CommonRequest { get; set; }
    }
}
