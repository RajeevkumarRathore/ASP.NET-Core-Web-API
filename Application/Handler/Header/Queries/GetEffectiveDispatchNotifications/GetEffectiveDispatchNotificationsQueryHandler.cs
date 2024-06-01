using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.Header;
using MediatR;
namespace Application.Handler.Header.Queries.GetEffectiveDispatchNotifications
{
    public class GetEffectiveDispatchNotificationsQueryHandler : IRequestHandler<GetEffectiveDispatchNotificationsQuery, CommonResultResponseDto<List<DispatchNotificationResponseDto>>>
    {
        private readonly IDispatcherNotificationsServices  _dispatcherNotificationsServices;
        public GetEffectiveDispatchNotificationsQueryHandler(IDispatcherNotificationsServices dispatcherNotificationsServices)
        {
            _dispatcherNotificationsServices = dispatcherNotificationsServices;
        }
        public async Task<CommonResultResponseDto<List<DispatchNotificationResponseDto>>> Handle(GetEffectiveDispatchNotificationsQuery  getEffectiveDispatchNotificationsQuery, CancellationToken cancellationToken)
        {
             return await _dispatcherNotificationsServices.GetEffectiveDispatchNotifications();           
        }
    }
}
