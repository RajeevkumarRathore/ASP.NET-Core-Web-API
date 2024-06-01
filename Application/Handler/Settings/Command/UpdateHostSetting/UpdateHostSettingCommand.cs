using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateHostSetting
{
    public class UpdateHostSettingCommand : IRequest<CommonResultResponseDto<Setting>>
    {
        public string Host1 { get; set; }
        public int Port1 { get; set; }
        public string Host2 { get; set; }
        public int Port2 { get; set; }
        public string FinalDestination { get; set; }
        public bool? SwitchHosts { get; set; }
    }
}
