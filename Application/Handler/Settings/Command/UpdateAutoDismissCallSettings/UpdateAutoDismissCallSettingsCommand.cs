using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateAutoDismissCallSettings
{
    public class UpdateAutoDismissCallSettingsCommand : IRequest<CommonResultResponseDto<Setting>>
    {
        public int DismissDelay { get; set; }
        public bool IsEnabled { get; set; }
    }
}
