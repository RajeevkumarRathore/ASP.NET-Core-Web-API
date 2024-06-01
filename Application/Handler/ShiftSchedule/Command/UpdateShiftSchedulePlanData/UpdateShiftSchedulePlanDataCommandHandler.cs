using Application.Abstraction.Services;
using DTO.Request.ShiftSchedule;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.ShiftSchedule.Command.UpdateShiftSchedulePlanData
{
    public class UpdateShiftSchedulePlanDataCommandHandler : IRequestHandler<UpdateShiftSchedulePlanDataCommand, CommonResultResponseDto<string>>
    {
        private readonly IShiftScheduleService _shiftScheduleService;
        public UpdateShiftSchedulePlanDataCommandHandler(IShiftScheduleService shiftScheduleService)
        {
            _shiftScheduleService = shiftScheduleService;    
        }
        public async Task<CommonResultResponseDto<string>> Handle(UpdateShiftSchedulePlanDataCommand updateShiftScheduleCommand, CancellationToken cancellationToken)
        {
            return await _shiftScheduleService.UpdateShiftSchedulePlanData(updateShiftScheduleCommand.Adapt<ShiftSchedulePlansRequestDto>());               
        }
    }
}
