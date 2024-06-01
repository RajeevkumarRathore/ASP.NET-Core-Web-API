using DTO.Request.ShiftSchedule;
using DTO.Response;
using MediatR;
namespace Application.Handler.ShiftSchedule.Command.CreateShiftSchedule
{
    public class CreateShiftScheduleCommand : IRequest<CommonResultResponseDto<CreateShiftScheduleRequestDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int ShiftTypeId { get; set; }
    }
}
