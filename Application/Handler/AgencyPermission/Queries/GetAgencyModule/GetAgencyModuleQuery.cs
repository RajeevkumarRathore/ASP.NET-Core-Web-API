using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.AgencyPermission.Queries.GetAgencyModule
{
    public class GetAgencyModuleQuery:IRequest<CommonResultResponseDto<List<AgencyModule>>>
    {

    }
}
