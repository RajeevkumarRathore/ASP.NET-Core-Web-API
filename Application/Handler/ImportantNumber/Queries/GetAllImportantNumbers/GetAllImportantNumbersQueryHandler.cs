using Application.Common.Response;
using DTO.Response;
using MediatR;
using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;
using DTO.Response.ImportantNumber;

namespace Application.Handler.ImportantNumber.Queries.GetAllImportantNumbers
{
    public class GetAllImportantNumbersQueryHandler : IRequestHandler<GetAllImportantNumbersQuery, CommonResultResponseDto<PaginatedList<GetAllImportantNumberResponseDto>>>
    {
        private readonly IImportantNumberService _importantNumberService;
        private readonly IRequestBuilder _requestBuilder;
        public GetAllImportantNumbersQueryHandler(IImportantNumberService importantNumberService, IRequestBuilder requestBuilder)
        {
            _importantNumberService = importantNumberService;
            _requestBuilder = requestBuilder;
        }
        public async Task<CommonResultResponseDto<PaginatedList<GetAllImportantNumberResponseDto>>> Handle(GetAllImportantNumbersQuery getAllImportantNumbersQuery, CancellationToken cancellationToken)
        {
            var filterModel = _requestBuilder.GetRequestBuilder(getAllImportantNumbersQuery.CommonRequest);
            return await _importantNumberService.GetAllImportantNumbers(filterModel.GetFilters(), getAllImportantNumbersQuery.CommonRequest, filterModel.GetSorts());
        }
    }
}
