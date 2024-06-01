using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Queries.GetMemberCounts
{
    public class GetMemberCountsQuery : IRequest<CommonResultResponseDto<MemberCounts>>
    {

    }
}
