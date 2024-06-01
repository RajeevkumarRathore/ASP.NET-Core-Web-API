using Application.Abstraction.Services;
using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Queries.GetShowHideMapviewTabSettings
{
    public class GetShowHideMapviewTabSettingsQueryHandler : IRequestHandler<GetShowHideMapviewTabSettingsQuery, CommonResultResponseDto<string>>
    {
        private readonly ISettingsService _settingsService;
        public GetShowHideMapviewTabSettingsQueryHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(GetShowHideMapviewTabSettingsQuery request, CancellationToken cancellationToken)
        {
            return await _settingsService.GetShowHideMapviewTabSettings();
        }
    }
}
