using DTO.Response;
using MediatR;
using DTO.Response.HighwayMapping;
using Application.Abstraction.Services;

namespace Application.Handler.HighwayMapping.Queries.GetAllHighwayName
{
    public class GetAllHighwayNameQueryHandler : IRequestHandler<GetAllHighwayNameQuery, CommonResultResponseDto<IList<GetAllHighwayNameResponseDto>>>
    {
        private readonly IHighwayMappingService _highwayMappingService;
   
        public GetAllHighwayNameQueryHandler(IHighwayMappingService highwayMappingService)
        {
            _highwayMappingService = highwayMappingService;
           
        }

        public async Task<CommonResultResponseDto<IList<GetAllHighwayNameResponseDto>>> Handle(GetAllHighwayNameQuery request, CancellationToken cancellationToken)
        {
            return await _highwayMappingService.GetAllHighwayName();
        }
    }
}
