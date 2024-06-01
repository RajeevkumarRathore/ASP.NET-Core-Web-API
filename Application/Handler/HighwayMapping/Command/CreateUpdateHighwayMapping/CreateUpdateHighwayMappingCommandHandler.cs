using DTO.Response;
using MediatR;
using DTO.Response.HighwayMapping;
using Application.Abstraction.Services;
using Mapster;
using DTO.Request.HighwayMapping;

namespace Application.Handler.HighwayMapping.Command.CreateUpdateHighwayMapping
{
    public class CreateUpdateHighwayMappingCommandHandler : IRequestHandler<CreateUpdateHighwayMappingCommand, CommonResultResponseDto<CreateUpdateHighwayMappingResponseDto>>
    {
        private readonly IHighwayMappingService _highwayMappingService;

        public CreateUpdateHighwayMappingCommandHandler(IHighwayMappingService highwayMappingService)
        {
            _highwayMappingService = highwayMappingService;

        }
        public async Task<CommonResultResponseDto<CreateUpdateHighwayMappingResponseDto>> Handle(CreateUpdateHighwayMappingCommand createUpdateHighwayMappingCommand, CancellationToken cancellationToken)
        {
            return await _highwayMappingService.CreateUpdateHighwayMapping(createUpdateHighwayMappingCommand.Adapt<CreateUpdateHighwayMappingRequestDto>());
        }
    }
}
