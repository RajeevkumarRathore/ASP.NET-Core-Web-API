using DTO.Request.Member;
using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Queries.GetNotificationsOnOffStatus
{
    public class GetNotificationsOnOffStatusQuery : IRequest<CommonResultResponseDto<GetNotificationsOnOffStatusRequest>>
    {
    }
}
