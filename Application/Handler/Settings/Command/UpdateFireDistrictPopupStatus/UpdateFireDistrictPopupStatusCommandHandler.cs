using Application.Abstraction.Services;
using Domain.Entities;
using DTO.Request.Settings;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateFireDistrictPopupStatus
{
    public class UpdateFireDistrictPopupStatusCommandHandler : IRequestHandler<UpdateFireDistrictPopupStatusCommand, CommonResultResponseDto<Setting>>
    {
        private readonly ISettingsService _settingsService;
        public UpdateFireDistrictPopupStatusCommandHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<Setting>> Handle(UpdateFireDistrictPopupStatusCommand updateFireDistrictPopupStatusCommand, CancellationToken cancellationToken)
        {
            return await _settingsService.UpdateFireDistrictPopupStatus(updateFireDistrictPopupStatusCommand.Adapt<UpdateFireDistrictPopupStatusRequestDto>());
        }
    }
}
