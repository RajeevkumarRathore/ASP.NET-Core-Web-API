using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.Settings;
using MediatR;

namespace Application.Handler.Settings.Queries.GetRadioChannel
{
    public class GetRadioChannelQueryHandler : IRequestHandler<GetRadioChannelQuery, CommonResultResponseDto<GetRadioChannelResponseDto>>
    {
        private readonly ISettingsService _settingsService;
        public GetRadioChannelQueryHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<GetRadioChannelResponseDto>> Handle(GetRadioChannelQuery request, CancellationToken cancellationToken)
        {
            return await _settingsService.GetRadioChannel();
        }
    }
}
