using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Queries.GetDuplicatePreventionSettings
{
    public class GetDuplicatePreventionSettingsQuery : IRequest<CommonResultResponseDto<string>>
    {
    }
}
