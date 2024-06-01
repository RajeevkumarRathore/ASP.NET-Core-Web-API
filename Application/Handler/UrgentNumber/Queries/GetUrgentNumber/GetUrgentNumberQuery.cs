using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using DTO.Response.UrgentNumber;
using MediatR;

namespace Application.Handler.UrgentNumber.Queries.GetUrgentNumber
{
    public class GetUrgentNumberQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<GetUrgentNumberResponseDto>>>
    {
        public ServerRowsRequest CommonRequest { get; set; }
    }
}
