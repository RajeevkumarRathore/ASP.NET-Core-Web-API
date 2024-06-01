using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using DTO.Response.HelpUsers;
using MediatR;

namespace Application.Handler.HelpUser.Queries.GetHelpUser
{
    public class GetHelpUserQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<HelpUsersResponseDto>>>
    {
        public ServerRowsRequest CommonRequest { get; set; }
    }
}
