using DTO.Response;
using MediatR;
using Application.Abstraction.Services;
using DTO.Response.Settings;

namespace Application.Handler.Settings.Queries.GetAutoCallStatusSettings
{
    public class GetAutoCallStatusSettingsQueryHandler : IRequestHandler<GetAutoCallStatusSettingsQuery, CommonResultResponseDto<AutoCallStatusResponseDto>>
    {
        private readonly ISettingsService _settingsService;
        public GetAutoCallStatusSettingsQueryHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<AutoCallStatusResponseDto>> Handle(GetAutoCallStatusSettingsQuery request, CancellationToken cancellationToken)
        {
            return await _settingsService.GetAutoCallStatusSettings();
        }
    }
}
