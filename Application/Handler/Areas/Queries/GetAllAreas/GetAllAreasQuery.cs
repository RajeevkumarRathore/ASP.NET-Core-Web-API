using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using MediatR;
using DTO.Response.Areas;

namespace Application.Handler.Areas.Queries.GetAllAreas
{
    public class GetAllAreasQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<GetAllAreasResponseDto>>>
    {
        public ServerRowsRequest CommonRequest { get; set; }
    }
}
