using DTO.Response;
using DTO.Response.ShiftSchedules;
using MediatR;
namespace Application.Handler.ShiftSchedule.Queries.GetShiftSchedulePlanData
{
    public class GetShiftSchedulePlanDataQuery : IRequest<CommonResultResponseDto<IList<ShiftSchedulePlanDatasResponseDto>>>
    {
        public int shiftTypeId { get; set; }
    }
}
