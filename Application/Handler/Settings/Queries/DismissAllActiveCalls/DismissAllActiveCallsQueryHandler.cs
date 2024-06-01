using Application.Abstraction.Services;
using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Queries.DismissAllActiveCalls
{
    public class DismissAllActiveCallsQueryHandler : IRequestHandler<DismissAllActiveCallsQuery, CommonResultResponseDto<string>>
    {
        private readonly ISettingsService _settingsService;
        public DismissAllActiveCallsQueryHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(DismissAllActiveCallsQuery request, CancellationToken cancellationToken)
        {
            return await _settingsService.DismissAllActiveCalls();
        }
    }
}
