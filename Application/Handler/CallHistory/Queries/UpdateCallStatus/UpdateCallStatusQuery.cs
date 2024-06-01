using DTO.Request.ClientInfo;
using DTO.Response;
using MediatR;

namespace Application.Handler.CallHistory.Queries.UpadateCallStatus
{
    public class UpdateCallStatusQuery : IRequest<CommonResultResponseDto<UpdateCallStatusRequestDto>>
    {
        public int ClientId { get; set; }
    }
}

