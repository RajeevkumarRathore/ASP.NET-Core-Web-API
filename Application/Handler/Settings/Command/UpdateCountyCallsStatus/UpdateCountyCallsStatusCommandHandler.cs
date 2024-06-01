using Application.Abstraction.Services;
using Domain.Entities;
using DTO.Request.Settings;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateCountyCallsStatus
{
    public class UpdateCountyCallsStatusCommandHandler : IRequestHandler<UpdateCountyCallsStatusCommand, CommonResultResponseDto<Setting>>
    {
        private readonly ISettingsService _settingsService;
        public UpdateCountyCallsStatusCommandHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<Setting>> Handle(UpdateCountyCallsStatusCommand updateCountyCallsStatusCommand, CancellationToken cancellationToken)
        {
            return await _settingsService.UpdateCountyCallsStatus(updateCountyCallsStatusCommand.Adapt<UpdateCountyCallsStatusRequestDto>());
        }
    }
}
