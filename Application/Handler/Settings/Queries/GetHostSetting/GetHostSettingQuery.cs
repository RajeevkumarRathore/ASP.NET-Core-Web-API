using DTO.Response.Settings;
using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Queries.GetHostSetting
{
    public class GetHostSettingQuery : IRequest<CommonResultResponseDto<HostSettingResponseDto>>
    {
    }
}
