using DTO.Response.AgencyPermission;
using MediatR;

namespace Application.Handler.AgencyPermission.Queries.GetAdminModulePermissionById
{
    public class GetAdminModulePermissionByIdQuery : IRequest<GetAdminModulePermissionResponseDto>
    {
        public int AgencyModuleId { get; set; }

    }
}
