using Application.Abstraction.Services;
using DTO.Request.ShiftSchedule;
using DTO.Response;
using Mapster;
using MediatR;
namespace Application.Handler.ShiftSchedule.Command.CreateShiftSchedule
{
    public class CreateShiftScheduleCommandHandler : IRequestHandler<CreateShiftScheduleCommand, CommonResultResponseDto<CreateShiftScheduleRequestDto>>
    {
        private readonly IShiftScheduleService _shiftScheduleService;
        public CreateShiftScheduleCommandHandler(IShiftScheduleService shiftScheduleService)
        {
            _shiftScheduleService = shiftScheduleService;
        }
        public async Task<CommonResultResponseDto<CreateShiftScheduleRequestDto>> Handle(CreateShiftScheduleCommand createShiftScheduleQuery, CancellationToken cancellationToken)
        {
            return await _shiftScheduleService.CreateShiftScheduleRequest(createShiftScheduleQuery.Adapt<CreateShiftScheduleRequestDto>());
        }
    }
}