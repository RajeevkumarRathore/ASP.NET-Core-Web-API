
using Application.Abstraction.Services;
using Application.Handler.Member.Command.AddMemberRadio;
using DTO.Request;
using DTO.Response;
using DTO.Response.Member;
using Mapster;
using MediatR;

namespace Application.Handler.Member.Queries.GetMemberMappedRadios
{
    public class GetMemberMappedRadiosQueryHandler : IRequestHandler<GetMemberMappedRadiosQuery, CommonResultResponseDto<IList<GetMemberMappedRadiosResponseDto>>>
    {
        private readonly IMemberService _memberService;
        public GetMemberMappedRadiosQueryHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<CommonResultResponseDto<IList<GetMemberMappedRadiosResponseDto>>> Handle(GetMemberMappedRadiosQuery  getMemberMappedRadiosQuery, CancellationToken cancellationToken)
        {
            return await _memberService.GetMemberMappedRadios(getMemberMappedRadiosQuery.memberId);
        }
    }
}
