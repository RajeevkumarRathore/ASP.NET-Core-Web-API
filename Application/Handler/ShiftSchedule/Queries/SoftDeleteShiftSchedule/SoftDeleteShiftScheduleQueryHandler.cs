using Application.Abstraction.Services;
using DTO.Response;
using MediatR;
namespace Application.Handler.ShiftSchedule.Queries.SoftDeleteShiftSchedule
{
    public class SoftDeleteShiftScheduleQueryHandler : IRequestHandler<SoftDeleteShiftScheduleQuery, CommonResultResponseDto<string>>
    {
        private readonly IShiftScheduleService _shiftScheduleService;
        public SoftDeleteShiftScheduleQueryHandler(IShiftScheduleService shiftScheduleService)
        {
            _shiftScheduleService = shiftScheduleService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(SoftDeleteShiftScheduleQuery softDeleteShiftScheduleQuery, CancellationToken cancellationToken)
        {
            return await _shiftScheduleService.SoftDeleteShiftSchedule(softDeleteShiftScheduleQuery.shiftScheduleId);
        }
    }
}
