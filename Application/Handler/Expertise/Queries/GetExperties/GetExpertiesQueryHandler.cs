using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;
using Application.Common.Response;
using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.Expertise.Queries.GetExperties
{
    public class GetExpertiesQueryHandler : IRequestHandler<GetExpertiesQuery, CommonResultResponseDto<PaginatedList<Expertises>>>
    {
        private readonly IExpertisesServices _expertisesServices;
        private readonly IRequestBuilder _requestBuilder;
        public GetExpertiesQueryHandler(IExpertisesServices expertisesServices, IRequestBuilder requestBuilder)
        {
            _expertisesServices = expertisesServices;
            _requestBuilder = requestBuilder;
        }
        public async Task<CommonResultResponseDto<PaginatedList<Expertises>>> Handle(GetExpertiesQuery getExpertiesQuery, CancellationToken cancellationToken)
        {
            var filterModel = _requestBuilder.GetRequestBuilder(getExpertiesQuery.CommonRequest);
            return await _expertisesServices.GetExperties(filterModel.GetFilters(), getExpertiesQuery.CommonRequest, filterModel.GetSorts());
        }
    }
}
