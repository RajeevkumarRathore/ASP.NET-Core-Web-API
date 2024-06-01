using Application.Common.Response;
using DTO.Response;
using MediatR;
using DTO.Response.HighwayMapping;
using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;

namespace Application.Handler.HighwayMapping.Queries.GetAllHighwayMapping
{
    public class GetAllHighwayMappingQueryHandler : IRequestHandler<GetAllHighwayMappingQuery, CommonResultResponseDto<PaginatedList<GetAllHighwayMappingResponseDto>>>
    {
        private readonly IHighwayMappingService _highwayMappingService;
        private readonly IRequestBuilder _requestBuilder;
        public GetAllHighwayMappingQueryHandler(IHighwayMappingService highwayMappingService, IRequestBuilder requestBuilder)
        {
            _highwayMappingService = highwayMappingService;
            _requestBuilder = requestBuilder;
        }
        public async  Task<CommonResultResponseDto<PaginatedList<GetAllHighwayMappingResponseDto>>> Handle(GetAllHighwayMappingQuery getAllHighwayMappingQuery, CancellationToken cancellationToken)
        {
            var filterModel = _requestBuilder.GetRequestBuilder(getAllHighwayMappingQuery.CommonRequest);
            return await _highwayMappingService.GetAllHighwayMapping(filterModel.GetFilters(), getAllHighwayMappingQuery.CommonRequest, filterModel.GetSorts());
        }
    }
}
