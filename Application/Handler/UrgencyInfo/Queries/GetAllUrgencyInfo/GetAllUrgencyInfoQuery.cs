using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using MediatR;
using DTO.Response.UrgencyInfo;

namespace Application.Handler.UrgencyInfo.Queries.GetAllUrgencyInfo
{
    public class GetAllUrgencyInfoQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<UrgencyInfoResponseDto>>>
    {
        public ServerRowsRequest CommonRequest { get; set; }
    }
}
