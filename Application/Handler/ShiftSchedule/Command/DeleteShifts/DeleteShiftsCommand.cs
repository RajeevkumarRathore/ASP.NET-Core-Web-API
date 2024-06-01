using DTO.Response;
using MediatR;
namespace Application.Handler.ShiftSchedule.Command.DeleteShifts
{
    public class DeleteShiftsCommand : IRequest<CommonResultResponseDto<string>>
    {
            public int shiftScheduleTakeId { get; set; }
            public int? dayOfWeek { get; set; }
            public int loggedInUserId { get; set; }
            public int selectedDeleteType { get; set; }

    }
}
