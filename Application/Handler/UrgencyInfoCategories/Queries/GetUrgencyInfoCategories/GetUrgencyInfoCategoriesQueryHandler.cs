using DTO.Response.UrgencyInfoCategories;
using DTO.Response;
using MediatR;
using Application.Abstraction.Services;

namespace Application.Handler.UrgencyInfoCategories.Queries.GetUrgencyInfoCategories
{
    public class GetUrgencyInfoCategoriesQueryHandler : IRequestHandler<GetUrgencyInfoCategoriesQuery, CommonResultResponseDto<IList<GetUrgencyInfoCategoryResponseDto>>>
    {
        private readonly IUrgencyInfoCategoriesService _urgencyInfoCategoriesService;
        public GetUrgencyInfoCategoriesQueryHandler(IUrgencyInfoCategoriesService urgencyInfoCategoriesService)
        {
            _urgencyInfoCategoriesService = urgencyInfoCategoriesService;
        }
        public async Task<CommonResultResponseDto<IList<GetUrgencyInfoCategoryResponseDto>>> Handle(GetUrgencyInfoCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _urgencyInfoCategoriesService.GetUrgencyInfoCategories();
        }
    }
}
