using Application.Abstraction.Services;
using DTO.Request.Settings;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateDatavancedPbxStatus
{
    public class UpdateDatavancedPbxStatusCommandHandler : IRequestHandler<UpdateDatavancedPbxStatusCommand, CommonResultResponseDto<string>>
    {
        private readonly ISettingsService _settingsService;
        public UpdateDatavancedPbxStatusCommandHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(UpdateDatavancedPbxStatusCommand updateDatavancedPbxStatusCommand, CancellationToken cancellationToken)
        {
            return await _settingsService.UpdateDatavancedPbxStatus(updateDatavancedPbxStatusCommand.Adapt<UpdateDatavancedPbxStatusRequestDto>());
        }
    }
}
