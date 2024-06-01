using DTO.Response;
using DTO.Response.Settings;
using MediatR;

namespace Application.Handler.Settings.Queries.GetClientInfoPageFontSizeSetting
{
    public class GetClientInfoPageFontSizeSettingQuery : IRequest<CommonResultResponseDto<FontSizeSettingResponseDto>>
    {
    }
}
