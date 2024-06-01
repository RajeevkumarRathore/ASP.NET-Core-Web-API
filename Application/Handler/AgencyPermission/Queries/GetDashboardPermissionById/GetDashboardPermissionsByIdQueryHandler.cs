using Application.Abstraction.Services;
using DTO.Response.AgencyPermission;
using MediatR;

namespace Application.Handler.AgencyPermission.Queries.GetDashboardPermission
{
    public class GetDashboardPermissionsByIdQueryHandler : IRequestHandler<GetDashboardPermissionsByIdQuery,DashboardPermissionResponseDto>
    {
        private readonly IAgencyPermissionService _agencyPermissionService;
        public GetDashboardPermissionsByIdQueryHandler(IAgencyPermissionService agencyPermissionService)
        {
            _agencyPermissionService = agencyPermissionService;
        }
        public  async Task<DashboardPermissionResponseDto> Handle(GetDashboardPermissionsByIdQuery  getDashboardPermissionsByIdQuery, CancellationToken cancellationToken)
        {
            return await _agencyPermissionService.GetDashboardPermissionById(getDashboardPermissionsByIdQuery.AgencyModuleId);
        }
    }
}
