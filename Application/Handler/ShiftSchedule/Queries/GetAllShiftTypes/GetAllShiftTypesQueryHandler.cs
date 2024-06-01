using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.ShiftSchedules;
using MediatR;
namespace Application.Handler.ShiftSchedule.Queries.GetAllShiftTypes
{
    public class GetAllShiftTypesQueryHandler : IRequestHandler<GetAllShiftTypesQuery, CommonResultResponseDto<IList<ShiftTypesResponseDto>>>
    {
        private readonly IShiftScheduleService _shiftScheduleService;
        public GetAllShiftTypesQueryHandler(IShiftScheduleService shiftScheduleService)
        {
           _shiftScheduleService = shiftScheduleService;
        }
        public async Task<CommonResultResponseDto<IList<ShiftTypesResponseDto>>> Handle(GetAllShiftTypesQuery request, CancellationToken cancellationToken)
        {
            return await _shiftScheduleService.GetRequestShiftTypes();
        }
    }
}
