using Domain.Entities;
using DTO.Request;
using DTO.Response;
using MediatR;

namespace Application.Handler.Header.Command.SaveDispatchNotification
{
    public class SaveDispatchNotificationCommand : IRequest<CommonResultResponseDto<DispatcherNotification>>
    {
        public int? HospitalId { get; set; }
        public int CreatedBy { get; set; }
        public string DispatchNotificationText { get; set; }
        public string EffectiveUntill { get; set; }
        public int dispatcherNotificationDaySelect { get; set; }
        public int? dispatcherNotificationMemberTypeSelect { get; set; }

    }
}
