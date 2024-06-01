using DTO.Request.Member;
using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Command.UpdateCallTextOnOffStatus
{
    public class UpdateCallTextOnOffStatusCommand : IRequest<CommonResultResponseDto<CallTextOnOffStatusRequestDto>>
    {
        public bool isCallTextOn { get; set; }
    }
}
