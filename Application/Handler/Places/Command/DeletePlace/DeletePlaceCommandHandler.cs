using Application.Abstraction.Services;
using DTO.Request.Places;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Places.Command.DeletePlace
{
    public class DeletePlaceCommandHandler : IRequestHandler<DeletePlaceCommand, CommonResultResponseDto<string>>
    {
        private readonly IPlaceService _placeService;

        public DeletePlaceCommandHandler(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        public async Task<CommonResultResponseDto<string>> Handle(DeletePlaceCommand deletePlaceCommand, CancellationToken cancellationToken)
        {
            return await _placeService.DeletePlace(deletePlaceCommand.Adapt<DeletePlaceRequestDto>());
        }
    }
}
