using DTO.Response;
using MediatR;
using Application.Abstraction.Services;
using DTO.Request.Report;

namespace Application.Handler.Settings.Queries.GetNotificationMessageValidTimeSetting
{
    public class GetNotificationMessageValidTimeSettingQueryHandler : IRequestHandler<GetNotificationMessageValidTimeSettingQuery, CommonResultResponseDto<JsonProperties>>
    {
        private readonly ISettingsService _settingsService;
        public GetNotificationMessageValidTimeSettingQueryHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<JsonProperties>> Handle(GetNotificationMessageValidTimeSettingQuery request, CancellationToken cancellationToken)
        {
            return await _settingsService.GetNotificationMessageValidTimeSetting();
        }
    }
}
