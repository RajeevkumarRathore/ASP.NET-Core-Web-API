using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateCalculateBusesParkingLocation
{
    public class UpdateCalculateBusesParkingLocationCommand : IRequest<CommonResultResponseDto<Setting>>
    {
        public bool IsEnabled { get; set; }
    }
}
