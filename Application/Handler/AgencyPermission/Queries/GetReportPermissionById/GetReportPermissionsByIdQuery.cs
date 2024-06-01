using DTO.Response.AgencyPermission;
using MediatR;

namespace Application.Handler.AgencyPermission.Queries.GetReportPermissionById
{
    public class GetReportPermissionsByIdQuery : IRequest<ReportPermissionResponseDto>
    {
        public int AgencyModuleId { get; set; }

    }
}
