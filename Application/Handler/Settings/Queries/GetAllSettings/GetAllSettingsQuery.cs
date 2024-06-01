using DTO.Response;
using DTO.Response.Settings;
using MediatR;

namespace Application.Handler.Settings.Queries.GetAllSettings
{
    public class GetAllSettingsQuery: IRequest<CommonResultResponseDto<GetAllSettingsResponseDto>>
    {
    }
}
