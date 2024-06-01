using DTO.Response.AgencyPermission;
using MediatR;

namespace Application.Handler.AgencyPermission.Queries.GetContactPermissionById
{
    public class GetContactPermissionsByIdQuery : IRequest<ContactPermissionResponseDto>
    {
        public int AgencyModuleId { get; set; }

    }
}
