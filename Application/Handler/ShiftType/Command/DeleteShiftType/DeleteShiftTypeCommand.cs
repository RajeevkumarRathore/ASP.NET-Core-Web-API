using DTO.Response;
using MediatR;

namespace Application.Handler.ShiftType.Command.DeleteShiftType
{
    public class DeleteShiftTypeCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int Id { get; set; }
    }
}
