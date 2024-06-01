using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Command.SaveAutoLogoutSettings
{
    public class SaveAutoLogoutSettingsCommand : IRequest<CommonResultResponseDto<Setting>>
    {
        public bool EnableAutoLogout { get; set; }
        public bool AutoLogoutOnShabbos { get; set; }
        public int AutoLogoutTime { get; set; }
        public int CountdownTime { get; set; }
    }
}
