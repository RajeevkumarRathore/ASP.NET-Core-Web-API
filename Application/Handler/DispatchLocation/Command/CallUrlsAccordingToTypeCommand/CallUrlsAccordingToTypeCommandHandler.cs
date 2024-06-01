using DTO.Response;
using MediatR;
using DTO.Request.DispatchLocation;
using Application.Abstraction.Services;
using Mapster;

namespace Application.Handler.DispatchLocation.Command.CallUrlsAccordingToTypeCommand
{
    public class CallUrlsAccordingToTypeCommandHandler : IRequestHandler<CallUrlsAccordingToTypeCommand, CommonResultResponseDto<DispatchLocationRequestDto>>
    {
        private readonly IDispatchLocationService _dispatchLocationService;
        public CallUrlsAccordingToTypeCommandHandler(IDispatchLocationService dispatchLocationService)
        {
            _dispatchLocationService = dispatchLocationService;
        }
        public async Task<CommonResultResponseDto<DispatchLocationRequestDto>> Handle(CallUrlsAccordingToTypeCommand callUrlsAccordingToTypeCommand, CancellationToken cancellationToken)
        {
            return await _dispatchLocationService.CallUrlsAccordingToType(callUrlsAccordingToTypeCommand.Adapt<DispatchLocationRequestDto>());
        }
    }
}
