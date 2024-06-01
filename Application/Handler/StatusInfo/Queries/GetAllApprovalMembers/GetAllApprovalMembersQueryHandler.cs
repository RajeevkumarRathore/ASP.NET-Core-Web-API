using DTO.Response;
using MediatR;
using Domain.Entities;
using Application.Abstraction.Services;
using Application.Common.Response;
using Application.Common.Interfaces.Common;

namespace Application.Handler.StatusInfo.Queries.GetAllApprovalMembers
{
    public class GetAllApprovalMembersQueryHandler : IRequestHandler<GetAllApprovalMembersQuery, CommonResultResponseDto<PaginatedList<ApprovalMemberResponseDto>>>
    {
        private readonly IStatusInfoService _statusInfoService;
        private readonly IRequestBuilder _requestBuilder;
        public GetAllApprovalMembersQueryHandler(IStatusInfoService statusInfoService, IRequestBuilder requestBuilder)
        {
            _statusInfoService = statusInfoService;
            _requestBuilder = requestBuilder;
        }
        public async Task<CommonResultResponseDto<PaginatedList<ApprovalMemberResponseDto>>> Handle(GetAllApprovalMembersQuery getAllApprovalMembersQuery, CancellationToken cancellationToken)
        {
            var filterModel = _requestBuilder.GetRequestBuilder(getAllApprovalMembersQuery.CommonRequest);
            return await _statusInfoService.GetAllApprovalMembers(filterModel.GetFilters(), getAllApprovalMembersQuery.CommonRequest, filterModel.GetSorts());
        }
    }
}
