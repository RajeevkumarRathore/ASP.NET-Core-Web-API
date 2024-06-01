using Application.Abstraction.Services;
using DTO.Request.ShiftSchedule;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.ShiftSchedule.Command.AddShifts
{
    public class AddShiftsCommandHandler : IRequestHandler<AddShiftsCommand, CommonResultResponseDto<string>>
    {
        private readonly IShiftScheduleService _shiftScheduleService;
        public AddShiftsCommandHandler(IShiftScheduleService shiftScheduleService)
        {
               _shiftScheduleService = shiftScheduleService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(AddShiftsCommand addShiftScheduleTakeFromCommand, CancellationToken cancellationToken)
        {
            return await _shiftScheduleService.AddShifts(addShiftScheduleTakeFromCommand.Adapt<ShiftScheduleDataRequestDto>());
        }
        
    }
}
