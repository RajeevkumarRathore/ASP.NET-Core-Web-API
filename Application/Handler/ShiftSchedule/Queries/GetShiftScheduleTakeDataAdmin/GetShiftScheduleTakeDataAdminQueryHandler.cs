using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.ShiftSchedules;
using MediatR;
namespace Application.Handler.ShiftSchedule.Queries.GetShiftScheduleTakeDataAdmin
{
    public class GetShiftScheduleTakeDataAdminQueryHandler : IRequestHandler<GetShiftScheduleTakeDataAdminQuery, CommonResultResponseDto<ShiftScheduleTakeDataViewResponseDto>>
    {
        private readonly IShiftScheduleService _shiftScheduleService;
        public GetShiftScheduleTakeDataAdminQueryHandler(IShiftScheduleService shiftScheduleService)
        {
          _shiftScheduleService = shiftScheduleService;
        }
        public async Task<CommonResultResponseDto<ShiftScheduleTakeDataViewResponseDto>>Handle(GetShiftScheduleTakeDataAdminQuery getShiftScheduleTakeDataAdminQuery, CancellationToken cancellationToken)
        {
            return await _shiftScheduleService.GetShiftScheduleTakeDataAdmin(getShiftScheduleTakeDataAdminQuery.shiftTypeId, getShiftScheduleTakeDataAdminQuery.startTime, getShiftScheduleTakeDataAdminQuery.endTime);
        }       
    }
}
