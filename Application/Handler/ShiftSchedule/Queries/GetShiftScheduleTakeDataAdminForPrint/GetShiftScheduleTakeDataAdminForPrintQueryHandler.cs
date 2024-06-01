using DTO.Response.ShiftSchedules;
using DTO.Response;
using MediatR;
using Application.Abstraction.Services;

namespace Application.Handler.ShiftSchedule.Queries.GetShiftScheduleTakeDataAdminForPrint
{
    public class GetShiftScheduleTakeDataAdminForPrintQueryHandler : IRequestHandler<GetShiftScheduleTakeDataAdminForPrintQuery, CommonResultResponseDto<ShiftScheduleTakeDataViewResponseDto>>
    {
        private readonly IShiftScheduleService _shiftScheduleService;
        public GetShiftScheduleTakeDataAdminForPrintQueryHandler(IShiftScheduleService shiftScheduleService)
        {
            _shiftScheduleService = shiftScheduleService;
        }
        public async Task<CommonResultResponseDto<ShiftScheduleTakeDataViewResponseDto>> Handle(GetShiftScheduleTakeDataAdminForPrintQuery getShiftScheduleTakeDataAdminForPrintQuery, CancellationToken cancellationToken)
        {
            return await _shiftScheduleService.GetShiftScheduleTakeDataAdminForPrint(getShiftScheduleTakeDataAdminForPrintQuery.shiftTypeId, getShiftScheduleTakeDataAdminForPrintQuery.startTime, getShiftScheduleTakeDataAdminForPrintQuery.endTime);
        }
    }
}
