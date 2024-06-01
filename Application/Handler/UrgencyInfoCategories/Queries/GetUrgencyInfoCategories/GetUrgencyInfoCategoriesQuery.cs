using DTO.Response.UrgencyInfoCategories;
using DTO.Response;
using MediatR;

namespace Application.Handler.UrgencyInfoCategories.Queries.GetUrgencyInfoCategories
{
    public class GetUrgencyInfoCategoriesQuery : IRequest<CommonResultResponseDto<IList<GetUrgencyInfoCategoryResponseDto>>>
    {
    }
}
