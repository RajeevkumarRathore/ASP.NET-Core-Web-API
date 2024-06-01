using Application.Abstraction.Services;
using Domain.Entities;
using DTO.Request.Settings;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateJsonProperty
{
    public class UpdateJsonPropertyCommandHandler : IRequestHandler<UpdateJsonPropertyCommand, CommonResultResponseDto<Setting>>
    {
        private readonly ISettingsService _settingsService;
        public UpdateJsonPropertyCommandHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<Setting>> Handle(UpdateJsonPropertyCommand updateJsonPropertyCommand, CancellationToken cancellationToken)
        {
            return await _settingsService.UpdateJsonProperty(updateJsonPropertyCommand.Adapt<UpdateJsonPropertyRequestDto>());
        }
    }
}
