using Application.Abstraction.Services;
using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Queries.GetShowHideAddressOnMapviewTabSettings
{
    public class GetShowHideAddressOnMapviewTabSettingsQueryHandler : IRequestHandler<GetShowHideAddressOnMapviewTabSettingsQuery, CommonResultResponseDto<string>>
    {
        private readonly ISettingsService _settingsService;
        public GetShowHideAddressOnMapviewTabSettingsQueryHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(GetShowHideAddressOnMapviewTabSettingsQuery request, CancellationToken cancellationToken)
        {
            return await _settingsService.GetShowHideAddressOnMapviewTabSettings();
        }
    }
}
