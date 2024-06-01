using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using MediatR;
using DTO.Response.Places;

namespace Application.Handler.Places.Queries
{
    public class GetAllPlacesQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<GetAllPlacesResponseDto>>>
    {
        public ServerRowsRequest CommonRequest { get; set; }
    }
}
