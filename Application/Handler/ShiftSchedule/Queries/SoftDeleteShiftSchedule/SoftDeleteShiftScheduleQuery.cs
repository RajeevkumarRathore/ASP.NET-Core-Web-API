using DTO.Response;
using MediatR;
namespace Application.Handler.ShiftSchedule.Queries.SoftDeleteShiftSchedule
{
    public class SoftDeleteShiftScheduleQuery : IRequest<CommonResultResponseDto<string>>
    {
        public int shiftScheduleId { get; set; }
    }
}
