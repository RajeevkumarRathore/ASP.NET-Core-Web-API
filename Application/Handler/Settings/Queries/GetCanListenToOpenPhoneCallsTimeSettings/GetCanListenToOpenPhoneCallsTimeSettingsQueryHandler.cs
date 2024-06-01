using DTO.Response.Settings;
using DTO.Response;
using MediatR;
using Application.Abstraction.Services;

namespace Application.Handler.Settings.Queries.GetCanListenToOpenPhoneCallsTimeSettings
{
    public class GetCanListenToOpenPhoneCallsTimeSettingsQueryHandler : IRequestHandler<GetCanListenToOpenPhoneCallsTimeSettingsQuery, CommonResultResponseDto<CanListenToOpenPhoneCallsTimeSettingsResponseDto>>
    {
        private readonly ISettingsService _settingsService;
        public GetCanListenToOpenPhoneCallsTimeSettingsQueryHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<CanListenToOpenPhoneCallsTimeSettingsResponseDto>> Handle(GetCanListenToOpenPhoneCallsTimeSettingsQuery request, CancellationToken cancellationToken)
        {
            return await _settingsService.GetCanListenToOpenPhoneCallsTimeSettings();
        }
    }
}
