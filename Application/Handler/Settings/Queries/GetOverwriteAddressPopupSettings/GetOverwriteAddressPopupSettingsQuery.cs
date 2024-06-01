using DTO.Response;
using DTO.Response.Settings;
using MediatR;

namespace Application.Handler.Settings.Queries.GetOverwriteAddressPopupSettings
{
    public class GetOverwriteAddressPopupSettingsQuery : IRequest<CommonResultResponseDto<OverwriteAddressPopupResponseDto>>
    {
    }
}
