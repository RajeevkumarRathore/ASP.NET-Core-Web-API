using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateCanListenToOpenPhoneCallsTimeSettings
{
    public class UpdateCanListenToOpenPhoneCallsTimeSettingsCommand : IRequest<CommonResultResponseDto<Setting>>
    {
        public string FromTime { get; set; } = "00:00:00";
        public string ToTime { get; set; } = "07:00:00";
    }
}
