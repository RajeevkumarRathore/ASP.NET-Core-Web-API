using DTO.Response.AgencyPermission;
using MediatR;

namespace Application.Handler.AgencyPermission.Queries.GetDashboardPermission
{
    public class GetDashboardPermissionsByIdQuery : IRequest<DashboardPermissionResponseDto>
    {
        public int AgencyModuleId { get; set; }
    }
}
