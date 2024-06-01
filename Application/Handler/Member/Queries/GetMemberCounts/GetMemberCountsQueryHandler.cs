using Application.Abstraction.Services;
using Application.Handler.Contact.Queries.GetHelpUsers;
using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Queries.GetMemberCounts
{
    public class GetMemberCountsQueryHandler : IRequestHandler<GetMemberCountsQuery, CommonResultResponseDto<MemberCounts>>
    {
        private readonly IMemberService _memberService;
        public GetMemberCountsQueryHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<CommonResultResponseDto<MemberCounts>> Handle(GetMemberCountsQuery request, CancellationToken cancellationToken)
        {
            return await _memberService.GetMemberCounts();
        }
    }
}
