using DTO.Response.Settings;
using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Queries.GetCountyCallsSetting
{
    public class GetCountyCallsSettingQuery : IRequest<CommonResultResponseDto<CountyCallsResponseDto>>
    {
    }
}
