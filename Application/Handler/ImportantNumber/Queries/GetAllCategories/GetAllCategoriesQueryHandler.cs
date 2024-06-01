using Application.Common.Response;
using DTO.Response;
using MediatR;
using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;
using DTO.Response.ImportantNumber;

namespace Application.Handler.ImportantNumber.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, CommonResultResponseDto<PaginatedList<GetAllCategoriesResponseDto>>>
    {
        private readonly IImportantNumberCategoriesService _importantNumberCategoriesService;
        private readonly IRequestBuilder _requestBuilder;
        public GetAllCategoriesQueryHandler(IImportantNumberCategoriesService importantNumberCategoriesService, IRequestBuilder requestBuilder)
        {
            _importantNumberCategoriesService = importantNumberCategoriesService;
            _requestBuilder = requestBuilder;
        }

        public async Task<CommonResultResponseDto<PaginatedList<GetAllCategoriesResponseDto>>> Handle(GetAllCategoriesQuery getAllCategoriesQuery, CancellationToken cancellationToken)
        {
            var filterModel = _requestBuilder.GetRequestBuilder(getAllCategoriesQuery.CommonRequest);
            return await _importantNumberCategoriesService.GetAllCategories(filterModel.GetFilters(), getAllCategoriesQuery.CommonRequest, filterModel.GetSorts());
        }
    }
}
