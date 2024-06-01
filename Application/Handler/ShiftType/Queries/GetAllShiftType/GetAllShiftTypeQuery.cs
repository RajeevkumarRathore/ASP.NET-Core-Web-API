using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using MediatR;
using DTO.Response.ShiftType;

namespace Application.Handler.ShiftType.Queries.GetAllShiftType
{
    public class GetAllShiftTypeQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<GetAllShiftTypeResponseDto>>>
    {
        public ServerRowsRequest CommonRequest { get; set; }
    }
}

