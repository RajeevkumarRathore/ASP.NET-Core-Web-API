using DTO.Response;
using MediatR;
using Domain.Entities;
using Application.Common.Dtos;
using Application.Common.Response;

namespace Application.Handler.StatusInfo.Queries.GetAllApprovalMembers
{
    public class GetAllApprovalMembersQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<ApprovalMemberResponseDto>>>
    {
        public ServerRowsRequest CommonRequest { get; set; }
    }
}
