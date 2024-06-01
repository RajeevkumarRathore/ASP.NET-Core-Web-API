using Application.Abstraction.Services;
using DTO.Request.HighwayMapping;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.HighwayMapping.Command.DeleteHighwayMapping
{
    public class DeleteHighwayMappingCommandHandler : IRequestHandler<DeleteHighwayMappingCommand, CommonResultResponseDto<string>>
    {
        private readonly IHighwayMappingService _highwayMappingService;
      
        public DeleteHighwayMappingCommandHandler(IHighwayMappingService highwayMappingService)
        {
            _highwayMappingService = highwayMappingService;
          
        }
        public async Task<CommonResultResponseDto<string>> Handle(DeleteHighwayMappingCommand deleteHighwayMappingCommand, CancellationToken cancellationToken)
        {
            return await _highwayMappingService.DeleteHighwayMapping(deleteHighwayMappingCommand.Adapt<DeleteHighwayMappingRequestDto>());
        }
    }
}
