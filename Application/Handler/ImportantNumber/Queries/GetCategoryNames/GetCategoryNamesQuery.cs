

using DTO.Response.ImportantNumber;
using DTO.Response;
using MediatR;

namespace Application.Handler.ImportantNumber.Queries.GetCategoryNames
{
    public class GetCategoryNamesQuery : IRequest<CommonResultResponseDto<IList<GetAllCategoriesResponseDto>>>
    {
    }
}
