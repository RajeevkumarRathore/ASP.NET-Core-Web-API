using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;
using Application.Common.Response;
using DTO.Response;
using DTO.Response.BusSection;
using MediatR;

namespace Application.Handler.BusSection.Queries.GetBusSection
{
    public class GetBusSectionQueryHandler : IRequestHandler<GetBusSectionQuery, CommonResultResponseDto<PaginatedList<GetBusSectionResponseDto>>>
    {
        private readonly IBusSectionService _busSectionService;
        private readonly IRequestBuilder _requestBuilder;
        public GetBusSectionQueryHandler(IBusSectionService busSectionService, IRequestBuilder requestBuilder)
        {
            _busSectionService = busSectionService;
            _requestBuilder = requestBuilder;
        }
        public async Task<CommonResultResponseDto<PaginatedList<GetBusSectionResponseDto>>> Handle(GetBusSectionQuery getBusSectionQuery, CancellationToken cancellationToken)
        {
            var filterModel = _requestBuilder.GetRequestBuilder(getBusSectionQuery.CommonRequest);
            return await _busSectionService.GetBusSection(filterModel.GetFilters(), getBusSectionQuery.CommonRequest, filterModel.GetSorts());
        }
    }
}
