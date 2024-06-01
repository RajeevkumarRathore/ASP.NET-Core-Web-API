using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.AgencyPermission.Queries.GetHeaderModule
{
    public class GetHeaderModuleQuery : IRequest<CommonResultResponseDto<List<HeaderModule>>>
    {
        public int Id { get; set; }
    }
}
