using Application.Abstraction.Services;
using DTO.Response;
using MediatR;

namespace Application.Handler.DispatchLocation.Command.DeleteDispatchLocation
{
    public class DeleteDispatchLocationCommandHandler : IRequestHandler<DeleteDispatchLocationCommand, CommonResultResponseDto<string>>
    {
        private readonly IDispatchLocationService _dispatchLocationService;
        public DeleteDispatchLocationCommandHandler(IDispatchLocationService dispatchLocationService)
        {
            _dispatchLocationService = dispatchLocationService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(DeleteDispatchLocationCommand deleteDispatchLocationCommand, CancellationToken cancellationToken)
        {
            return await _dispatchLocationService.DeleteDispatchLocation(deleteDispatchLocationCommand.Id);
        }
    }
}
