using Application.Abstraction.Services;
using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.AgencyPermission.Queries.GetHeaderModule
{
    public class GetHeaderModuleQueryHandler : IRequestHandler<GetHeaderModuleQuery, CommonResultResponseDto<List<HeaderModule>>>
    {
        private readonly IAgencyPermissionService  _agencyPermissionService;
        public GetHeaderModuleQueryHandler(IAgencyPermissionService  agencyPermissionService)
        {
            _agencyPermissionService = agencyPermissionService;
        }
        public async Task<CommonResultResponseDto<List<HeaderModule>>> Handle(GetHeaderModuleQuery getHeaderModuleQuery, CancellationToken cancellationToken)
        {
            return await _agencyPermissionService.GetHeaderModule(getHeaderModuleQuery.Id);
        }
    }
}
