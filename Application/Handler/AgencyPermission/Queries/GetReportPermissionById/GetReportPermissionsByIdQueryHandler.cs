using Application.Abstraction.Services;
using DTO.Response.AgencyPermission;
using MediatR;

namespace Application.Handler.AgencyPermission.Queries.GetReportPermissionById
{
    public class GetReportPermissionsByIdQueryHandler : IRequestHandler<GetReportPermissionsByIdQuery,ReportPermissionResponseDto>
    {
        private readonly IAgencyPermissionService _agencyPermissionService;
        public GetReportPermissionsByIdQueryHandler(IAgencyPermissionService agencyPermissionService)
        {
            _agencyPermissionService = agencyPermissionService;
        }

        public async Task<ReportPermissionResponseDto> Handle(GetReportPermissionsByIdQuery  getReportPermissionByIdQuery, CancellationToken cancellationToken)
        {
            return await _agencyPermissionService.GetReportPermissionById(getReportPermissionByIdQuery.AgencyModuleId);
        }
    }
}
