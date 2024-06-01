using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateEnableDisableAutoDismissCallSwitch
{
    public class UpdateEnableDisableAutoDismissCallSwitchCommand : IRequest<CommonResultResponseDto<Setting>>
    {
        public bool IsEnabled { get; set; }
    }
}
