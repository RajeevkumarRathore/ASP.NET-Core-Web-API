using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Queries.GetShowHideAddressOnMapviewTabSettings
{
    public class GetShowHideAddressOnMapviewTabSettingsQuery : IRequest<CommonResultResponseDto<string>>
    {
    }
}
