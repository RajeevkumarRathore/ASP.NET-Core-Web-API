using DTO.Response;
using MediatR;
using DTO.Response.Places;
using Application.Abstraction.Services;
using DTO.Request.Places;
using Mapster;

namespace Application.Handler.Places.Command.CreateUpdatePlace
{
    public class CreateUpdatePlaceCommandHandler : IRequestHandler<CreateUpdatePlaceCommand, CommonResultResponseDto<CreateUpdatePlaceResponseDto>>
    {
        private readonly IPlaceService _placeService;
       
        public CreateUpdatePlaceCommandHandler(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        public async  Task<CommonResultResponseDto<CreateUpdatePlaceResponseDto>> Handle(CreateUpdatePlaceCommand createUpdatePlaceCommand, CancellationToken cancellationToken)
        {
            return await _placeService.CreateUpdatePlace(createUpdatePlaceCommand.Adapt<CreateUpdatePlaceRequestDto>());
        }
    }
}
