using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using MediatR;
using DTO.Response.HighwayMapping;

namespace Application.Handler.HighwayMapping.Queries.GetAllHighwayMapping
{
    public class GetAllHighwayMappingQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<GetAllHighwayMappingResponseDto>>>
    {
        public ServerRowsRequest CommonRequest { get; set; }
    }
    
    
}
