using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.Settings;
using MediatR;

namespace Application.Handler.Settings.Queries.GetAllSettings
{
    public class GetAllSettingsQueryHandler : IRequestHandler<GetAllSettingsQuery, CommonResultResponseDto<GetAllSettingsResponseDto>>
    {
        private readonly ISettingsService _settingsService;
        public GetAllSettingsQueryHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<GetAllSettingsResponseDto>> Handle(GetAllSettingsQuery request, CancellationToken cancellationToken)
        {
            return await _settingsService.GetAllSettings();
        }
    }
}
