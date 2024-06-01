using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using DTO.Response.CallStatus;
using MediatR;

namespace Application.Handler.CallStatus.Queries.GetAllCallStatus
{
    public class GetAllCallStatusQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<CallStatusResponseDto>>>
    {
        public ServerRowsRequest CommonRequest { get; set; }
    }
}
