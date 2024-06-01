using DTO.Response;
using MediatR;
using DTO.Response.Cities;
using Application.Abstraction.Services;
using DTO.Request.Cities;
using Mapster;

namespace Application.Handler.Cities.Command.CreateUpdateCities
{
    public class CreateUpdateCitiesCommandHandler : IRequestHandler<CreateUpdateCitiesCommand, CommonResultResponseDto<CreateUpdateCitiesResponseDto>>
    {
        private readonly ICitiesService _citiesService;
     
        public CreateUpdateCitiesCommandHandler(ICitiesService citiesService)
        {
            _citiesService = citiesService;
           
        }

        public async  Task<CommonResultResponseDto<CreateUpdateCitiesResponseDto>> Handle(CreateUpdateCitiesCommand createUpdateCitiesCommand, CancellationToken cancellationToken)
        {
            return await _citiesService.CreateUpdateCities(createUpdateCitiesCommand.Adapt<CreateUpdateCitiesRequestDto>());
        }
    }
}
