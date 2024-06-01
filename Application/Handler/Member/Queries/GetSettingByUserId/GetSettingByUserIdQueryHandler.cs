

using Application.Abstraction.Services;
using Application.Handler.Member.Queries.GetMemberMappedRadios;
using DTO.Response;
using DTO.Response.Member;
using MediatR;

namespace Application.Handler.Member.Queries.GetSettingByUserId
{
    public class GetSettingByUserIdQueryHandler : IRequestHandler<GetSettingByUserIdQuery, CommonResultResponseDto<ResMemberViewModel>>
    {
        private readonly IMemberService _memberService;
        public GetSettingByUserIdQueryHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<CommonResultResponseDto<ResMemberViewModel>> Handle(GetSettingByUserIdQuery getSettingByUserIdQuery, CancellationToken cancellationToken)
        {
            return await _memberService.GetSettingByUserId(getSettingByUserIdQuery.user_id);
        }
    }
}
