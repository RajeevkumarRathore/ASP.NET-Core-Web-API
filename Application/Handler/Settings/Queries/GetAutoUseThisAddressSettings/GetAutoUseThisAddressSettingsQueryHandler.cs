using DTO.Response.Settings;
using DTO.Response;
using MediatR;
using Application.Abstraction.Services;

namespace Application.Handler.Settings.Queries.GetAutoUseThisAddressSettings
{
    public class GetAutoUseThisAddressSettingsQueryHandler : IRequestHandler<GetAutoUseThisAddressSettingsQuery, CommonResultResponseDto<AutoUseThisAddressResponseDto>>
    {
        private readonly ISettingsService _settingsService;
        public GetAutoUseThisAddressSettingsQueryHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<AutoUseThisAddressResponseDto>> Handle(GetAutoUseThisAddressSettingsQuery request, CancellationToken cancellationToken)
        {
            return await _settingsService.GetAutoUseThisAddressSettings();
        }
    }
}
