using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.Settings;
using MediatR;

namespace Application.Handler.Settings.Queries.GetOverwriteAddressPopupSettings
{
    public class GetOverwriteAddressPopupSettingsQueryHandler : IRequestHandler<GetOverwriteAddressPopupSettingsQuery, CommonResultResponseDto<OverwriteAddressPopupResponseDto>>
    {
        private readonly ISettingsService _settingsService;
        public GetOverwriteAddressPopupSettingsQueryHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<OverwriteAddressPopupResponseDto>> Handle(GetOverwriteAddressPopupSettingsQuery request, CancellationToken cancellationToken)
        {
            return await _settingsService.GetOverwriteAddressPopupSettings();
        }
    }
}
