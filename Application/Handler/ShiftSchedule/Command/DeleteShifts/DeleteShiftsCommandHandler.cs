using Application.Abstraction.Services;
using DTO.Request.ShiftSchedule;
using DTO.Response;
using Mapster;
using MediatR;
namespace Application.Handler.ShiftSchedule.Command.DeleteShifts
{
    public class DeleteShiftsCommandHandler : IRequestHandler<DeleteShiftsCommand, CommonResultResponseDto<string>>
    {
        private readonly IShiftScheduleService _shiftScheduleService;
        public DeleteShiftsCommandHandler(IShiftScheduleService shiftScheduleService)
        {
             _shiftScheduleService = shiftScheduleService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(DeleteShiftsCommand deleteShiftScheduleTakeWebCommand, CancellationToken cancellationToken)
        {
           return await _shiftScheduleService.DeleteShifts(deleteShiftScheduleTakeWebCommand.Adapt<DeleteShiftsRequestDto>());
        }
    }
}
