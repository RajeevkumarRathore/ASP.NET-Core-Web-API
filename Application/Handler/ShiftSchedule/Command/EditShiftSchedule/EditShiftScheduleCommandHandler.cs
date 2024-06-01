using Application.Abstraction.Services;
using DTO.Request.ShiftSchedule;
using DTO.Response;
using Mapster;
using MediatR;
namespace Application.Handler.ShiftSchedule.Command.EditShiftSchedule
{
    public class EditShiftScheduleCommandHandler : IRequestHandler<EditShiftScheduleCommand, CommonResultResponseDto<string>>
    {
        private readonly IShiftScheduleService _shiftScheduleService;
        public EditShiftScheduleCommandHandler(IShiftScheduleService shiftScheduleService)
        {
           _shiftScheduleService = shiftScheduleService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(EditShiftScheduleCommand editShiftScheduleCommand, CancellationToken cancellationToken)
        {
            return await _shiftScheduleService.EditShiftSchedule(editShiftScheduleCommand.Adapt<EditShiftScheduleRequestDto>());
        }
    }
}
