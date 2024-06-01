
using Application.Abstraction.Services;
using DTO.Request.Member;
using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Queries.GetAllBadgeNumbers
{
    public class GetAllBadgeNumbersQueryHandler : IRequestHandler<GetAllBadgeNumbersQuery, CommonResultResponseDto<IList<GetBadgeNumbersRequestDto>>>
    {
        private readonly IMemberService _memberService;
        public GetAllBadgeNumbersQueryHandler(IMemberService memberService)
        {
               _memberService = memberService;
        }
        public async Task<CommonResultResponseDto<IList<GetBadgeNumbersRequestDto>>> Handle(GetAllBadgeNumbersQuery getAllBadgeNumbersQuery, CancellationToken cancellationToken)
        {
            return await _memberService.GetAllBadgeNumbers();
        }
    }
}
