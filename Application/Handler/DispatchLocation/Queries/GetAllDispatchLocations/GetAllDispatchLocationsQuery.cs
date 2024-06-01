using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using MediatR;
using DTO.Response.DispatchLocation;

namespace Application.Handler.DispatchLocation.Queries.GetAllDispatchLocations
{
    public class GetAllDispatchLocationsQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<DispatchLocationsResponseDto>>>
    {
        public ServerRowsRequest CommonRequest { get; set; }
    }
}
