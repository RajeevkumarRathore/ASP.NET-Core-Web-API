using Application.Abstraction.Services;
using DTO.Request.DispatchLocation;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.DispatchLocation.Command.UpdateIsBayStatus
{
    public class UpdateIsBayStatusCommandHandler : IRequestHandler<UpdateIsBayStatusCommand, CommonResultResponseDto<string>>
    {
        private readonly IDispatchLocationService _dispatchLocationService;
        public UpdateIsBayStatusCommandHandler(IDispatchLocationService dispatchLocationService)
        {
            _dispatchLocationService = dispatchLocationService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(UpdateIsBayStatusCommand updateIsBayStatusCommand, CancellationToken cancellationToken)
        {
            return await _dispatchLocationService.UpdateIsBayStatus(updateIsBayStatusCommand.Adapt<UpdateIsBayStatusRequestDto>());
        }
    }
}
