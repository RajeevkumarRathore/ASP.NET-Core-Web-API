using Application.Abstraction.Services;
using DTO.Response;
using MediatR;

namespace Application.Handler.CallStatus.Command.DeleteCallStatus
{
    public class DeleteCallStatusCommandHandler : IRequestHandler<DeleteCallStatusCommand, CommonResultResponseDto<string>>
    {
        private readonly ICallStatusService _callStatusService;
        public DeleteCallStatusCommandHandler(ICallStatusService callStatusService)
        {
            _callStatusService = callStatusService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(DeleteCallStatusCommand deleteCallStatusCommand, CancellationToken cancellationToken)
        {
            return await _callStatusService.DeleteCallStatus(deleteCallStatusCommand.Id);
        }
    }
}
