using Application.Common.Response;
using DTO.Response;
using MediatR;
using DTO.Response.GetAllText;
using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;

namespace Application.Handler.ShortTextMessage.Queries.GetAllText
{
    public class GetAllTextQueryHandler : IRequestHandler<GetAllTextQuery, CommonResultResponseDto<PaginatedList<GetAllTextResponseDto>>>
    {
        private readonly IShortTextMessageService _shortTextMessageService;
        private readonly IRequestBuilder _requestBuilder;
        public GetAllTextQueryHandler(IShortTextMessageService shortTextMessageService, IRequestBuilder requestBuilder)
        {
            _shortTextMessageService = shortTextMessageService;
            _requestBuilder = requestBuilder;
        }
        public async Task<CommonResultResponseDto<PaginatedList<GetAllTextResponseDto>>> Handle(GetAllTextQuery getAllTextQuery, CancellationToken cancellationToken)
        {
            var filterModel = _requestBuilder.GetRequestBuilder(getAllTextQuery.CommonRequest);
            return await _shortTextMessageService.GetAllText(filterModel.GetFilters(), getAllTextQuery.CommonRequest, filterModel.GetSorts());
        }
    }
}
