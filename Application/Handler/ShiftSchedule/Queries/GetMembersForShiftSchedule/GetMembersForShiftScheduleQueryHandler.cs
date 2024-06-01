using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.ShiftSchedules;
using MediatR;
namespace Application.Handler.ShiftSchedule.Queries.GetMembersForShiftSchedule
{
    public class GetMembersForShiftScheduleQueryHandler : IRequestHandler<GetMembersForShiftScheduleQuery, CommonResultResponseDto<AllMembersClassifiedForShiftResponseDto>>
    {
        private readonly IShiftScheduleService _shiftScheduleService;
        public GetMembersForShiftScheduleQueryHandler(IShiftScheduleService shiftScheduleService)
        {
           _shiftScheduleService = shiftScheduleService;
        }
        public async Task<CommonResultResponseDto<AllMembersClassifiedForShiftResponseDto>> Handle(GetMembersForShiftScheduleQuery request, CancellationToken cancellationToken)
        {
            return await _shiftScheduleService.GetMembersForShiftSchedule();
        }
    }
}
