using DTO.Response;
using MediatR;

namespace Application.Handler.ShiftSchedule.Command.UpdateShiftSchedulePlanData
{
    public class UpdateShiftSchedulePlanDataCommand: IRequest<CommonResultResponseDto<string>>
    {
        public UpdateShiftSchedulePlanDataCommand()
        {
            ShiftSchedulesDto = new List<ShiftSchedulePlanRequestDto>();
        }
        public List<ShiftSchedulePlanRequestDto> ShiftSchedulesDto { get; set; }
    }
    public class ShiftSchedulePlanRequestDto
    {
        public int shiftScheduleId { get; set; }
        public int dayOfWeek { get; set; }
        public int shiftTypeId { get; set; }
    }
}


