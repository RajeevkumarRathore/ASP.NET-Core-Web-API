using DTO.Response.Settings;
using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Queries.GetCanListenToOpenPhoneCallsTimeSettings
{
    public class GetCanListenToOpenPhoneCallsTimeSettingsQuery : IRequest<CommonResultResponseDto<CanListenToOpenPhoneCallsTimeSettingsResponseDto>>
    {
    }
}
