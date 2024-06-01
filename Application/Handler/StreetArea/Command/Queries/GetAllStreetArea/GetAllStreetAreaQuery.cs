using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using MediatR;
using DTO.Response.StreetArea;

namespace Application.Handler.StreetArea.Command.Queries.GetAllStreetArea
{
    public class GetAllStreetAreaQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<GetAllStreetAreaResponseDto>>>
    {
        public ServerRowsRequest CommonRequest { get; set; }
    }
}
