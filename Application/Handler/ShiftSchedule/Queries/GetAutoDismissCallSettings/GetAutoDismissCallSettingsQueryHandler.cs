using Application.Abstraction.Services;
using DTO.Request.ShiftSchedule;
using DTO.Response;
using MediatR;

namespace Application.Handler.ShiftSchedule.Queries.GetAutoDismissCallSettings
{
    public class GetAutoDismissCallSettingsQueryHandler : IRequestHandler<GetAutoDismissCallSettingsQuery, CommonResultResponseDto<AutoDismissCallRequestDto>>
    {
        private readonly IShiftScheduleService _shiftScheduleService;
        public GetAutoDismissCallSettingsQueryHandler(IShiftScheduleService shiftScheduleService)
        {
            _shiftScheduleService = shiftScheduleService;
        }
        public async Task<CommonResultResponseDto<AutoDismissCallRequestDto>> Handle(GetAutoDismissCallSettingsQuery getAutoDismissCallSettingsQuery, CancellationToken cancellationToken)
        {
            return await _shiftScheduleService.GetAutoDismissCallSettings();
        }
    }
}
