using DTO.Response;
using MediatR;
using Application.Abstraction.Services;
using DTO.Response.Settings;

namespace Application.Handler.Settings.Queries.GetDispatchDelay
{
    public class GetDispatchDelayQueryHandler : IRequestHandler<GetDispatchDelayQuery, CommonResultResponseDto<DispatchAlertResponseDto>>
    {
        private readonly ISettingsService _settingsService;
        public GetDispatchDelayQueryHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<DispatchAlertResponseDto>> Handle(GetDispatchDelayQuery request, CancellationToken cancellationToken)
        {
            return await _settingsService.GetDispatchDelay();
        }
    }
}
