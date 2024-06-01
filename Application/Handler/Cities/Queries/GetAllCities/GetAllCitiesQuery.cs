using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using MediatR;
using DTO.Response.Cities;

namespace Application.Handler.Cities.Queries.GetAllCities
{
    public class GetAllCitiesQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<GetAllCitiesResponseDto>>>
    {
        public ServerRowsRequest CommonRequest { get; set; }
    }
}
