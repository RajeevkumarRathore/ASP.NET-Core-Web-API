using DTO.Response.Settings;
using DTO.Response;
using MediatR;
using Application.Abstraction.Services;

namespace Application.Handler.Settings.Queries.GetCalculateBusesParkingLocationSetting
{
    public class GetCalculateBusesParkingLocationSettingQueryHandler : IRequestHandler<GetCalculateBusesParkingLocationSettingQuery, CommonResultResponseDto<GetCalculateBusesParkingLocationSettingResponseDto>>
    {
        private readonly ISettingsService _settingsService;
        public GetCalculateBusesParkingLocationSettingQueryHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<GetCalculateBusesParkingLocationSettingResponseDto>> Handle(GetCalculateBusesParkingLocationSettingQuery request, CancellationToken cancellationToken)
        {
            return await _settingsService.GetCalculateBusesParkingLocationSetting();
        }
    }
}

