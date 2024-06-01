using Application.Abstraction.Services;
using DTO.Request.ShiftType;
using DTO.Response;
using DTO.Response.ShiftType;
using Mapster;
using MediatR;

namespace Application.Handler.ShiftType.Command.CreateUpdateShiftType
{
    public class CreateUpdateShiftTypeCommandHandler : IRequestHandler<CreateUpdateShiftTypeCommand, CommonResultResponseDto<CreateUpdateShiftTypeResponseDto>>
    {
        private readonly IShiftTypeService _shiftTypeService;

        public CreateUpdateShiftTypeCommandHandler(IShiftTypeService shiftTypeService)
        {
            _shiftTypeService = shiftTypeService;

        }
        public async Task<CommonResultResponseDto<CreateUpdateShiftTypeResponseDto>> Handle(CreateUpdateShiftTypeCommand createUpdateShiftTypeCommand, CancellationToken cancellationToken)
        {
            return await _shiftTypeService.CreateUpdateShiftType(createUpdateShiftTypeCommand.Adapt<CreateUpdateShiftTypeRequestDto>());
        }
    }
}
