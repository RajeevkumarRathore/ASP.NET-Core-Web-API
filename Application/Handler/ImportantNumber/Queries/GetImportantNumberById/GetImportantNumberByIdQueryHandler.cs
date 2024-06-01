using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;
using Application.Common.Response;
using DTO.Response;
using DTO.Response.ImportantNumber;
using MediatR;

namespace Application.Handler.ImportantNumber.Queries.GetImportantNumberById
{
    public class GetImportantNumberByIdQueryHandler : IRequestHandler<GetImportantNumberByIdQuery, CommonResultResponseDto<PaginatedList<GetAllImportantNumberResponseDto>>>
    {
        private readonly IImportantNumberService _importantNumberService;
        private readonly IRequestBuilder _requestBuilder;
        public GetImportantNumberByIdQueryHandler(IImportantNumberService importantNumberService, IRequestBuilder requestBuilder)
        {
            _importantNumberService = importantNumberService;
            _requestBuilder = requestBuilder;
        }
        public async Task<CommonResultResponseDto<PaginatedList<GetAllImportantNumberResponseDto>>> Handle(GetImportantNumberByIdQuery getImportantNumberByIdQuery, CancellationToken cancellationToken)
        {
            var filterModel = _requestBuilder.GetRequestBuilder(getImportantNumberByIdQuery.CommonRequest);
            return await _importantNumberService.GetImportantNumberById(filterModel.GetFilters(), getImportantNumberByIdQuery.CommonRequest,getImportantNumberByIdQuery.Id, filterModel.GetSorts());
        }
    }
}
