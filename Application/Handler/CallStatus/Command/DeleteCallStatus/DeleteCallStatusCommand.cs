using DTO.Response;
using MediatR;

namespace Application.Handler.CallStatus.Command.DeleteCallStatus
{
    public class DeleteCallStatusCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int Id { get; set; }
    }
}
