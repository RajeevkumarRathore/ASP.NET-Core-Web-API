
using Application.Abstraction.Services;
using Application.Handler.Member.Queries.GetSettingByUserId;
using DTO.Response;
using DTO.Response.Member;
using MediatR;

namespace Application.Handler.Member.Queries.GetContactInfoByUserId
{
    public class GetContactInfoByUserIdQueryHandler : IRequestHandler<GetContactInfoByUserIdQuery, CommonResultResponseDto<IList<ResMemberPhoneInfo>>>
    {
        private readonly IMemberService _memberService;
        public GetContactInfoByUserIdQueryHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<CommonResultResponseDto<IList<ResMemberPhoneInfo>>> Handle(GetContactInfoByUserIdQuery  getContactInfoByUserIdQuery, CancellationToken cancellationToken)
        {
            return await _memberService.GetContactInfoByUserId(getContactInfoByUserIdQuery.user_id);
        }
    }
}
