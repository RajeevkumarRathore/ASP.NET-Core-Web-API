using Application.Abstraction.Services;
using DTO.Response.AgencyPermission;
using MediatR;

namespace Application.Handler.AgencyPermission.Queries.GetAdminModulePermissionById
{
    public class GetAdminModulePermissionByIdQueryHandler : IRequestHandler<GetAdminModulePermissionByIdQuery, GetAdminModulePermissionResponseDto>
    {
        private readonly IAgencyPermissionService _agencyPermissionService;
        public GetAdminModulePermissionByIdQueryHandler(IAgencyPermissionService agencyPermissionService)
        {
            _agencyPermissionService = agencyPermissionService;
        }

        public async Task<GetAdminModulePermissionResponseDto> Handle(GetAdminModulePermissionByIdQuery getAdminModulePermissionByIdQuery, CancellationToken cancellationToken)
        {
            return await _agencyPermissionService.GetAdminModulePermissionById(getAdminModulePermissionByIdQuery.AgencyModuleId);
        }
    }
}
