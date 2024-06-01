using DTO.Response;
using MediatR;

namespace Application.Handler.CallStatus.Command.CreateUpdateCallStatus
{
    public class CreateUpdateCallStatusCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int RowNumber { get; set; }
    }
}
