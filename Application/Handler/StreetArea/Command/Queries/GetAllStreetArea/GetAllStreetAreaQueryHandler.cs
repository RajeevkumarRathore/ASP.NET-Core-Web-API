using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;
using Application.Common.Response;
using DTO.Response;
using MediatR;
using DTO.Response.StreetArea;

namespace Application.Handler.StreetArea.Command.Queries.GetAllStreetArea
{
    public class GetAllStreetAreaQueryHandler : IRequestHandler<GetAllStreetAreaQuery, CommonResultResponseDto<PaginatedList<GetAllStreetAreaResponseDto>>>
    {
        private readonly IStreetAreaService _streetAreaService;
        private readonly IRequestBuilder _requestBuilder;
        public GetAllStreetAreaQueryHandler(IStreetAreaService streetAreaService, IRequestBuilder requestBuilder)
        {
            _streetAreaService = streetAreaService;
            _requestBuilder = requestBuilder;
        }

        public async  Task<CommonResultResponseDto<PaginatedList<GetAllStreetAreaResponseDto>>> Handle(GetAllStreetAreaQuery getAllStreetAreaQuery, CancellationToken cancellationToken)
        {
            var filterModel = _requestBuilder.GetRequestBuilder(getAllStreetAreaQuery.CommonRequest);
            return await _streetAreaService.GetAllStreetArea(filterModel.GetFilters(), getAllStreetAreaQuery.CommonRequest, filterModel.GetSorts());
        }
    }
}
