using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using DTO.Response.BusSection;
using MediatR;

namespace Application.Handler.BusSection.Queries.GetBusSection
{
    public class GetBusSectionQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<GetBusSectionResponseDto>>>
    {
        public ServerRowsRequest CommonRequest { get; set; }
    }
}
