using DTO.Response;
using MediatR;
using DTO.Response.DispatchLocation;
using Application.Abstraction.Services;
using Mapster;
using DTO.Request.DispatchLocation;

namespace Application.Handler.DispatchLocation.Command.CreateUpdateDispatchLocation
{
    public class CreateUpdateDispatchLocationCommandHandler : IRequestHandler<CreateUpdateDispatchLocationCommand, CommonResultResponseDto<CreateUpdateDispatchLocationResponseDto>>
    {
        private readonly IDispatchLocationService _dispatchLocationService;
        public CreateUpdateDispatchLocationCommandHandler(IDispatchLocationService dispatchLocationService)
        {
            _dispatchLocationService = dispatchLocationService;
        }
        public async Task<CommonResultResponseDto<CreateUpdateDispatchLocationResponseDto>> Handle(CreateUpdateDispatchLocationCommand createUpdateDispatchLocationCommand, CancellationToken cancellationToken)
        {
            return await _dispatchLocationService.CreateUpdateDispatchLocation(createUpdateDispatchLocationCommand.Adapt<CreateUpdateDispatchLocationRequestDto>());
        }
    }
}
