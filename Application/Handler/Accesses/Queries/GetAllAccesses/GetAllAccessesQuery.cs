using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using DTO.Response.Accesses;
using MediatR;

namespace Application.Handler.Accesses.Queries.GetAllAccesses
{
    public class GetAllAccessesQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<AccessesResponseDto>>>
    {
        public ServerRowsRequest CommonRequest { get; set; }
    }
}
