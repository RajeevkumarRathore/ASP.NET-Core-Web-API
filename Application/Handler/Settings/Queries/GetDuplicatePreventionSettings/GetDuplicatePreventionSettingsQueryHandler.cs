using DTO.Response;
using MediatR;
using Application.Abstraction.Services;

namespace Application.Handler.Settings.Queries.GetDuplicatePreventionSettings
{
    public class GetDuplicatePreventionSettingsQueryHandler : IRequestHandler<GetDuplicatePreventionSettingsQuery, CommonResultResponseDto<string>>
    {
        private readonly ISettingsService _settingsService;
        public GetDuplicatePreventionSettingsQueryHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(GetDuplicatePreventionSettingsQuery request, CancellationToken cancellationToken)
        {
            return await _settingsService.GetDuplicatePreventionSettings();
        }
    }
}
