using Application.Abstraction.Services;
using DTO.Request.Settings;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateCreativePbxStatus
{
    public class UpdateCreativePbxStatusCommandHandler : IRequestHandler<UpdateCreativePbxStatusCommand, CommonResultResponseDto<string>>
    {
        private readonly ISettingsService _settingsService;
        public UpdateCreativePbxStatusCommandHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(UpdateCreativePbxStatusCommand updateCreativePbxStatusCommand, CancellationToken cancellationToken)
        {
            return await _settingsService.UpdateCreativePbxStatus(updateCreativePbxStatusCommand.Adapt<UpdateCreativePbxStatusRequestDto>());
        }
    }
}
