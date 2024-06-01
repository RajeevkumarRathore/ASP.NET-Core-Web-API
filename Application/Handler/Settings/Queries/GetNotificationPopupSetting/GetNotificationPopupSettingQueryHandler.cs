using DTO.Response;
using MediatR;
using Application.Abstraction.Services;
using DTO.Response.Settings;

namespace Application.Handler.Settings.Queries.GetNotificationPopupSetting
{
    public class GetNotificationPopupSettingQueryHandler : IRequestHandler<GetNotificationPopupSettingQuery, CommonResultResponseDto<NotificationPopupResponseDto>>
    {
        private readonly ISettingsService _settingsService;
        public GetNotificationPopupSettingQueryHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<NotificationPopupResponseDto>> Handle(GetNotificationPopupSettingQuery request, CancellationToken cancellationToken)
        {
            return await _settingsService.GetNotificationPopupSetting();
        }
    }
}
