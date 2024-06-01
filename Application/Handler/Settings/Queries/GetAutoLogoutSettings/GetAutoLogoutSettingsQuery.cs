using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Queries.GetAutoLogoutSettings
{
    public class GetAutoLogoutSettingsQuery : IRequest<CommonResultResponseDto<string>>
    {
    }
}
