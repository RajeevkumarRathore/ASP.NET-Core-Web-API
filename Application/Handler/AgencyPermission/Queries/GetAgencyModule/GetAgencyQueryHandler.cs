using Application.Abstraction.Services;
using Application.Handler.AgencyPermission.Queries.GetAgencyModule;
using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.AgencyPermission.Queries.GetHeaderModule
{
    public class GetAgencyQueryHandler : IRequestHandler<GetAgencyModuleQuery, CommonResultResponseDto<List<AgencyModule>>>
    {
        private readonly IAgencyPermissionService _agencyPermissionService;
        public GetAgencyQueryHandler(IAgencyPermissionService  agencyPermissionService)
        {
            _agencyPermissionService = agencyPermissionService;   
        }

        public async Task<CommonResultResponseDto<List<AgencyModule>>> Handle(GetAgencyModuleQuery getHeaderModuleQuery, CancellationToken cancellationToken)
        {
            return await _agencyPermissionService.GetAgencyModule();
        }
    }
}
