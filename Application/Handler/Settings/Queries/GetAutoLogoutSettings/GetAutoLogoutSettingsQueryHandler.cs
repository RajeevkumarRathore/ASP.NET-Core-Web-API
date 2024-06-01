using Application.Abstraction.Services;
using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Queries.GetAutoLogoutSettings
{
    public class GetAutoLogoutSettingsQueryHandler : IRequestHandler<GetAutoLogoutSettingsQuery, CommonResultResponseDto<string>>
    {
        private readonly ISettingsService _settingsService;
        public GetAutoLogoutSettingsQueryHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(GetAutoLogoutSettingsQuery request, CancellationToken cancellationToken)
        {
            return await _settingsService.GetAutoLogoutSettings();
        }
    }
}
