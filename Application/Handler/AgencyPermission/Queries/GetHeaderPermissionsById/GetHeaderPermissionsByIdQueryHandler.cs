using DTO.Response.AgencyPermission;
using MediatR;
using Application.Abstraction.Services;

namespace Application.Handler.AgencyPermission.Queries.GetModulePermissionsById
{
    public class GetHeaderPermissionsByIdQueryHandler : IRequestHandler<GetHeaderPermissionsByIdQuery, HeaderPermissionResponseDto>
    {
        private readonly IAgencyPermissionService _agencyPermissionService;
        public GetHeaderPermissionsByIdQueryHandler(IAgencyPermissionService agencyPermissionService)
        {
            _agencyPermissionService = agencyPermissionService;
        }

        public async Task<HeaderPermissionResponseDto> Handle(GetHeaderPermissionsByIdQuery  getHeaderPermissionsByIdQuery, CancellationToken cancellationToken)
        {
            return await _agencyPermissionService.GetHeaderPermissionById(getHeaderPermissionsByIdQuery.AgencyModuleId);
        }
    }
}
