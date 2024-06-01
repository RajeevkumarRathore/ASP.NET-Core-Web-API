using DTO.Response;
using DTO.Response.Header;
using MediatR;
namespace Application.Handler.Header.Queries.GetEffectiveDispatchNotifications
{
    public class GetEffectiveDispatchNotificationsQuery : IRequest<CommonResultResponseDto<List<DispatchNotificationResponseDto>>>
    {
    }
}
