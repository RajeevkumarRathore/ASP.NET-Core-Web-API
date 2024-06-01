using DTO.Request.Report;
using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Queries.GetNotificationMessageValidTimeSetting
{
    public class GetNotificationMessageValidTimeSettingQuery : IRequest<CommonResultResponseDto<JsonProperties>>
    {
    }
}
