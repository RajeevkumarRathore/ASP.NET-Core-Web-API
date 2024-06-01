using DTO.Request.Member;
using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Command.UpdateGeneralNotificationsOnOffStatus
{
    public class UpdateGeneralNotificationsOnOffStatusCommand : IRequest<CommonResultResponseDto<GetNotificationsOnOffStatusRequest>>
    {
        public bool isGeneralNotificationsOn { get; set; }
    }
}
