using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using MediatR;

using DTO.Response.StatusInfos;

namespace Application.Handler.StatusInfo.Queries.GetAllStatusInfo
{
    public class GetAllStatusInfoQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<StatusInfosResponseDto>>>
    {
        public ServerRowsRequest CommonRequest { get; set; }
    }
}
