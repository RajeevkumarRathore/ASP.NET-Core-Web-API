using Application.Common.Response;
using DTO.Response;
using MediatR;
using DTO.Response.AgencyPermission;
using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;

namespace Application.Handler.AgencyPermission.Queries.GetAgencyPermission
{
    public class GetAgencyPermissionByModuleIdQueryHandler : IRequestHandler<GetAgencyPermissionByModuleIdQuery, CommonResultResponseDto<PaginatedList<GetAgencyPermissionByModuleIdResponseDto>>>
    {
        private readonly IAgencyPermissionService _agencyPermissionService;
        private readonly IRequestBuilder _requestBuilder;
        public GetAgencyPermissionByModuleIdQueryHandler(IAgencyPermissionService  agencyPermissionService, IRequestBuilder requestBuilder)
        {
            _agencyPermissionService = agencyPermissionService;
            _requestBuilder = requestBuilder;
        }
        public async Task<CommonResultResponseDto<PaginatedList<GetAgencyPermissionByModuleIdResponseDto>>> Handle(GetAgencyPermissionByModuleIdQuery getAgencyPermissionByModuleIdQuery, CancellationToken cancellationToken)
        {
            var filterModel = _requestBuilder.GetRequestBuilder(getAgencyPermissionByModuleIdQuery);
            return await _agencyPermissionService.GetAgencyPermissionByModuleId(filterModel.GetFilters(), getAgencyPermissionByModuleIdQuery,filterModel.GetSorts(),getAgencyPermissionByModuleIdQuery.AgencyModuleId);
        }
    }
}
