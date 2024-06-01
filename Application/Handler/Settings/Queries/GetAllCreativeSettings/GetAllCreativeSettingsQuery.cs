using DTO.Response;
using DTO.Response.Settings;
using MediatR;

namespace Application.Handler.Settings.Queries.GetAllCreativeSettings
{
    public class GetAllCreativeSettingsQuery : IRequest<CommonResultResponseDto<CreativeSettingsResponseDto>>
    {
    }
}
