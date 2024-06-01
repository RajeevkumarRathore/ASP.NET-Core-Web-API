using DTO.Response.Settings;
using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Queries.GetAutoCallStatusSettings
{
    public class GetAutoCallStatusSettingsQuery : IRequest<CommonResultResponseDto<AutoCallStatusResponseDto>>
    {
    }
}
