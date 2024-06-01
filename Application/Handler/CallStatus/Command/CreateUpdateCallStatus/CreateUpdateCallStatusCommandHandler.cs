using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.CallStatus;
using Mapster;
using MediatR;

namespace Application.Handler.CallStatus.Command.CreateUpdateCallStatus
{
    public class CreateUpdateCallStatusCommandHandler : IRequestHandler<CreateUpdateCallStatusCommand, CommonResultResponseDto<string>>
    {
        private readonly ICallStatusService _callStatusService;
        public CreateUpdateCallStatusCommandHandler(ICallStatusService callStatusService)
        {
            _callStatusService = callStatusService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(CreateUpdateCallStatusCommand createUpdateCallStatusCommand, CancellationToken cancellationToken)
        {
            return await _callStatusService.CreateUpdateCallStatus(createUpdateCallStatusCommand.Adapt<CreateUpdateCallStatusRequestDto>());
        }
    }
}
