using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using DTO.Response.Member;
using MediatR;

namespace Application.Handler.Member.Queries.GetAllMembers
{
    public class GetAllMembersQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<MemberViewModel>>>
    {
        public ServerRowsRequest CommonRequest { get; set; }
        public string currentUserRoleId { get; set; }
    }
}
