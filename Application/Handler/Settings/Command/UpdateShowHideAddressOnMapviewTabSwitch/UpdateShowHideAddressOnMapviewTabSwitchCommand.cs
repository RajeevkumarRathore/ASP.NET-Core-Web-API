using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateShowHideAddressOnMapviewTabSwitch
{
    public class UpdateShowHideAddressOnMapviewTabSwitchCommand : IRequest<CommonResultResponseDto<Setting>>
    {
        public bool IsEnabled { get; set; }
    }
}
