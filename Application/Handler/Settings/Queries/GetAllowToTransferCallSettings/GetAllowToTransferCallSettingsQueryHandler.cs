using DTO.Response.Settings;
using DTO.Response;
using MediatR;
using Application.Abstraction.Services;

namespace Application.Handler.Settings.Queries.GetAllowToTransferCallSettings
{
    public class GetAllowToTransferCallSettingsQueryHandler : IRequestHandler<GetAllowToTransferCallSettingsQuery, CommonResultResponseDto<AllowToTransferCallResponseDto>>
    {
        private readonly ISettingsService _settingsService;
        public GetAllowToTransferCallSettingsQueryHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<AllowToTransferCallResponseDto>> Handle(GetAllowToTransferCallSettingsQuery request, CancellationToken cancellationToken)
        {
            return await _settingsService.GetAllowToTransferCallSettings();
        }
    }
}
