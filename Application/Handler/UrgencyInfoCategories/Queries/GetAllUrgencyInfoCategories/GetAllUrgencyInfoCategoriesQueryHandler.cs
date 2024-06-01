using Application.Common.Response;
using DTO.Response;
using MediatR;
using DTO.Response.UrgencyInfoCategories;
using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;

namespace Application.Handler.UrgencyInfoCategories.Queries.GetAllUrgencyInfoCategories
{
    public class GetAllUrgencyInfoCategoriesQueryHandler : IRequestHandler<GetAllUrgencyInfoCategoriesQuery, CommonResultResponseDto<PaginatedList<GetAllUrgencyInfoCategoriesResponseDto>>>
    {
        private readonly IUrgencyInfoCategoriesService  _urgencyInfoCategoriesService;
        private readonly IRequestBuilder _requestBuilder;
        public GetAllUrgencyInfoCategoriesQueryHandler(IUrgencyInfoCategoriesService urgencyInfoCategoriesService, IRequestBuilder requestBuilder)
        {
            _urgencyInfoCategoriesService = urgencyInfoCategoriesService;
            _requestBuilder = requestBuilder;
        }
        public async Task<CommonResultResponseDto<PaginatedList<GetAllUrgencyInfoCategoriesResponseDto>>> Handle(GetAllUrgencyInfoCategoriesQuery getAllUrgencyInfoCategoriesQuery, CancellationToken cancellationToken)
        {
            var filterModel = _requestBuilder.GetRequestBuilder(getAllUrgencyInfoCategoriesQuery.CommonRequest);
            return await _urgencyInfoCategoriesService.GetAllUrgencyInfoCategories(filterModel.GetFilters(), getAllUrgencyInfoCategoriesQuery.CommonRequest, filterModel.GetSorts());
        }
    }
}
