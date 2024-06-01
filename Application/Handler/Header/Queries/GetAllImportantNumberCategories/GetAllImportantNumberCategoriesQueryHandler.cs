using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.Header;
using MediatR;

namespace Application.Handler.Header.Queries.getAllImportantNumberCategories
{
    public class GetAllImportantNumberCategoriesQueryHandler : IRequestHandler<GetAllImportantNumberCategoriesQuery, CommonResultResponseDto<List<ImportantNumberCategoriesResponseDto>>>
    {
        private readonly IImportantNumberCategoriesService _importantNumberCategoriesService;
        public GetAllImportantNumberCategoriesQueryHandler(IImportantNumberCategoriesService importantNumberCategoriesService)
        {
            _importantNumberCategoriesService = importantNumberCategoriesService;
        }
        public async Task<CommonResultResponseDto<List<ImportantNumberCategoriesResponseDto>>> Handle(GetAllImportantNumberCategoriesQuery getAllImportantNumberCategoriesQuery, CancellationToken cancellationToken)
        {
            return await _importantNumberCategoriesService.GetAllImportantNumberCategories();
        }
    }
}
