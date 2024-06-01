using DTO.Response.AgencyPermission;
using MediatR;

namespace Application.Handler.AgencyPermission.Queries.GetMemberPermissionById
{
    public class GetMemberPermissionsByIdQuery : IRequest<MemberPermissionResponseDto>
    {
        public int AgencyModuleId { get; set; }

    }
}
