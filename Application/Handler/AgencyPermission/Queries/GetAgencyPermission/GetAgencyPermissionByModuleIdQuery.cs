using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using MediatR;
using DTO.Response.AgencyPermission;

namespace Application.Handler.AgencyPermission.Queries.GetAgencyPermission
{
    public class GetAgencyPermissionByModuleIdQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<GetAgencyPermissionByModuleIdResponseDto>>>
    {
        public ServerRowsRequest CommonRequest { get; set; }
        public int AgencyModuleId { get; set; }
    }
}
