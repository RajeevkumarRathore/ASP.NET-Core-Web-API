using DTO.Request.ShiftSchedule;
using DTO.Response;
using MediatR;
namespace Application.Handler.ShiftSchedule.Queries.GetAutoDismissCallSettings
{
    public class GetAutoDismissCallSettingsQuery : IRequest<CommonResultResponseDto<AutoDismissCallRequestDto>>
    {
    }
}
