using DTO.Response;
using DTO.Response.Settings;
using MediatR;

namespace Application.Handler.Settings.Queries.GetFireDistrictPopupSetting
{
    public class GetFireDistrictPopupSettingQuery : IRequest<CommonResultResponseDto<FireDistrictPopupSettingResponseDto>>
    {
    }
}
