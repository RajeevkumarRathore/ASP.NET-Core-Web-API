using DTO.Response;
using DTO.Response.Header;
using MediatR;
namespace Application.Handler.Header.Queries.getAllImportantNumberCategories
{
    public class GetAllImportantNumberCategoriesQuery : IRequest<CommonResultResponseDto<List<ImportantNumberCategoriesResponseDto>>>
    {

    }
}
