using Application.Abstraction.Services;
using DTO.Request.Header;
using DTO.Response;
using DTO.Response.Header;
using Mapster;
using MediatR;
namespace Application.Handler.Header.Queries.GetAllImportantNumbers
{
    public class GetAllImportantNumbersQueryHandler : IRequestHandler<GetImportantNumbersQuery, CommonResultResponseDto<List<ImportantNumbersResponseDto>>>
    {
        private readonly IImportantNumberCategoriesService  _importantNumberCategoriesService;
        public GetAllImportantNumbersQueryHandler(IImportantNumberCategoriesService importantNumberCategoriesService)
        {
            _importantNumberCategoriesService = importantNumberCategoriesService;
        }
        public async Task<CommonResultResponseDto<List<ImportantNumbersResponseDto>>> Handle(GetImportantNumbersQuery getAllImportantNumbersQuery, CancellationToken cancellationToken)
        {

            return await _importantNumberCategoriesService.GetImportantNumbers(getAllImportantNumbersQuery.Adapt<ImportantNumberRequestDto>());
        }
    }
}
