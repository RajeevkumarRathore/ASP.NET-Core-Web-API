using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.ShiftSchedules;
using MediatR;

namespace Application.Handler.ShiftSchedule.Queries.GetShiftSchedulePlanData
{
    public class GetShiftSchedulePlanDataQueryHandler : IRequestHandler<GetShiftSchedulePlanDataQuery, CommonResultResponseDto<IList<ShiftSchedulePlanDatasResponseDto>>>
    {
        private readonly IShiftScheduleService _shiftScheduleService;
        public GetShiftSchedulePlanDataQueryHandler(IShiftScheduleService shiftScheduleService)
        {
                _shiftScheduleService = shiftScheduleService;
        }
        public async Task<CommonResultResponseDto<IList<ShiftSchedulePlanDatasResponseDto>>> Handle(GetShiftSchedulePlanDataQuery request, CancellationToken cancellationToken)
        {
            return await _shiftScheduleService.GetShiftSchedulePlanData(request.shiftTypeId);
        }
    }
}
