using DTO.Response.ShiftSchedules;
using DTO.Response;
using MediatR;

namespace Application.Handler.ShiftSchedule.Queries.GetShiftScheduleTakeDataAdminForPrint
{
    public class GetShiftScheduleTakeDataAdminForPrintQuery : IRequest<CommonResultResponseDto<ShiftScheduleTakeDataViewResponseDto>>
    {
        public int shiftTypeId { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
    }
}
