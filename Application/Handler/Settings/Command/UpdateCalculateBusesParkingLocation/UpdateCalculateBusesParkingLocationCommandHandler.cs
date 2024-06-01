using Application.Abstraction.Services;
using Domain.Entities;
using DTO.Request.Settings;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateCalculateBusesParkingLocation
{
    public class UpdateCalculateBusesParkingLocationCommandHandler : IRequestHandler<UpdateCalculateBusesParkingLocationCommand, CommonResultResponseDto<Setting>>
    {
        private readonly ISettingsService _settingsService;
        public UpdateCalculateBusesParkingLocationCommandHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<Setting>> Handle(UpdateCalculateBusesParkingLocationCommand updateCalculateBusesParkingLocationCommand, CancellationToken cancellationToken)
        {
            return await _settingsService.UpdateCalculateBusesParkingLocation(updateCalculateBusesParkingLocationCommand.Adapt<UpdateCalculateBusesParkingLocationRequestDto>());
        }
    }
}
