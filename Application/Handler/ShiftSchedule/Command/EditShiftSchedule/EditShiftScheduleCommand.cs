using DTO.Response;
using MediatR;
namespace Application.Handler.ShiftSchedule.Command.EditShiftSchedule
{
    public class EditShiftScheduleCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public int shiftTypeId { get; set; }
    }
}
