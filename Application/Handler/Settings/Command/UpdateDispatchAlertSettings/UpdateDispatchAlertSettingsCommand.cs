using DTO.Response;
using MediatR;
using Domain.Entities;

namespace Application.Handler.Settings.Command.UpdateDispatchAlertSettings
{
    public class UpdateDispatchAlertSettingsCommand : IRequest<CommonResultResponseDto<Setting>>
    {
        public int StartingDelay { get; set; } = 60000;
        public int StartingDelayMonitor { get; set; } = 60000;
        public int CountDown { get; set; } = 60000;
        public string ValidityStartTime { get; set; } = "00:00:00";
        public string ValidityEndTime { get; set; } = "06:00:00";
    }
}
