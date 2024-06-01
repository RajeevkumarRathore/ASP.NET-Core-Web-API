using Application.Abstraction.Services;
using DTO.Request.Cities;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Cities.Command.DeleteCities
{
    public class DeleteCitiesCommandHandler : IRequestHandler<DeleteCitiesCommand, CommonResultResponseDto<string>>
    {
        private readonly ICitiesService _citiesService;

        public DeleteCitiesCommandHandler(ICitiesService citiesService)
        {
            _citiesService = citiesService;

        }

        public async Task<CommonResultResponseDto<string>> Handle(DeleteCitiesCommand deleteCitiesCommand, CancellationToken cancellationToken)
        {
            return await _citiesService.DeleteCities(deleteCitiesCommand.Adapt<DeleteCitiesRequestDto>());
        }
    }
}
