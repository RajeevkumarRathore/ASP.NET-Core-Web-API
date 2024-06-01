using DTO.Response;
using DTO.Response.ShiftSchedules;
using MediatR;

namespace Application.Handler.ShiftSchedule.Queries.GetShiftScheduleTakeDataAdmin
{
    public class GetShiftScheduleTakeDataAdminQuery : IRequest<CommonResultResponseDto<ShiftScheduleTakeDataViewResponseDto>>
    {
        public int shiftTypeId { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
    }
}
