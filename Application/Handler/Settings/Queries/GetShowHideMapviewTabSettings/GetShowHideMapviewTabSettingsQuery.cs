using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Queries.GetShowHideMapviewTabSettings
{
    public class GetShowHideMapviewTabSettingsQuery : IRequest<CommonResultResponseDto<string>>
    {
    }
}
