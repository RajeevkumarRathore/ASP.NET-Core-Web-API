using DTO.Response.AgencyPermission;
using MediatR;

namespace Application.Handler.AgencyPermission.Queries.GetModulePermissionsById
{
    public class GetHeaderPermissionsByIdQuery : IRequest<HeaderPermissionResponseDto>
    {
        public int AgencyModuleId { get; set; }
      
    }
}
