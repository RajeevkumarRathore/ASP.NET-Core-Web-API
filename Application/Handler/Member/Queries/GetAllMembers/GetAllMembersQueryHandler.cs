using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;
using Application.Common.Response;
using DTO.Response;
using DTO.Response.Member;
using Google.Apis.Requests;
using MediatR;

namespace Application.Handler.Member.Queries.GetAllMembers
{
    public class GetAllMembersQueryHandler : IRequestHandler<GetAllMembersQuery, CommonResultResponseDto<PaginatedList<MemberViewModel>>>
    {
        private readonly IMemberService _memberService;
        private readonly IRequestBuilder _requestBuilder;
        public GetAllMembersQueryHandler(IMemberService memberService, IRequestBuilder requestBuilder)
        {
            _memberService = memberService;
            _requestBuilder = requestBuilder;
        }
        public async Task<CommonResultResponseDto<PaginatedList<MemberViewModel>>> Handle(GetAllMembersQuery getAllMembersQuery, CancellationToken cancellationToken)
        {
            var filterModel = _requestBuilder.GetRequestBuilder(getAllMembersQuery.CommonRequest);
            return await _memberService.GetAllMembers(filterModel.GetFilters(), getAllMembersQuery.CommonRequest, getAllMembersQuery.currentUserRoleId, filterModel.GetSorts());

        }
    }
}
