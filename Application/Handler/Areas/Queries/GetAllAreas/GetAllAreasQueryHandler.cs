using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;
using Application.Common.Response;
using DTO.Response;
using MediatR;
using DTO.Response.Areas;

namespace Application.Handler.Areas.Queries.GetAllAreas
{
    public class GetAllAreasQueryHandler : IRequestHandler<GetAllAreasQuery, CommonResultResponseDto<PaginatedList<GetAllAreasResponseDto>>>
    {
        private readonly IAreasService _areasService;
        private readonly IRequestBuilder _requestBuilder;
        public GetAllAreasQueryHandler(IAreasService areasService, IRequestBuilder requestBuilder)
        {
            _areasService = areasService;
            _requestBuilder = requestBuilder;
        }

        public  async Task<CommonResultResponseDto<PaginatedList<GetAllAreasResponseDto>>> Handle(GetAllAreasQuery getAllAreasQuery, CancellationToken cancellationToken)
        {
            var filterModel = _requestBuilder.GetRequestBuilder(getAllAreasQuery.CommonRequest);
            return await _areasService.GetAllAreas(filterModel.GetFilters(), getAllAreasQuery.CommonRequest, filterModel.GetSorts());
        }
    }
}
