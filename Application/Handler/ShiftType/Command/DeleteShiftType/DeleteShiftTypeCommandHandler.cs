using Application.Abstraction.Services;
using DTO.Request.ShiftType;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.ShiftType.Command.DeleteShiftType
{
    public class DeleteShiftTypeCommandHandler : IRequestHandler<DeleteShiftTypeCommand, CommonResultResponseDto<string>>
    {
        private readonly IShiftTypeService _shiftTypeService;
      
        public DeleteShiftTypeCommandHandler(IShiftTypeService shiftTypeService)
        {
            _shiftTypeService = shiftTypeService;
           
        }

        public async Task<CommonResultResponseDto<string>> Handle(DeleteShiftTypeCommand deleteShiftTypeCommand, CancellationToken cancellationToken)
        {
            return await _shiftTypeService.DeleteShiftType(deleteShiftTypeCommand.Adapt<DeleteShiftTypeRequestDto>());
        }
    }
}
