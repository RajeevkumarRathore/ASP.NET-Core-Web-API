using Application.Common.Response;
using DTO.Response;
using MediatR;
using DTO.Response.UrgentNumber;
using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;

namespace Application.Handler.UrgentNumber.Queries.GetUrgentNumber
{
    public class GetUrgentNumberQueryHandler : IRequestHandler<GetUrgentNumberQuery, CommonResultResponseDto<PaginatedList<GetUrgentNumberResponseDto>>>
    {
        private readonly IUrgentNumberService _urgentNumberService;
        private readonly IRequestBuilder _requestBuilder;
        public GetUrgentNumberQueryHandler(IUrgentNumberService urgentNumberService, IRequestBuilder requestBuilder)
        {
            _urgentNumberService = urgentNumberService;
             _requestBuilder = requestBuilder;
        }
        public async Task<CommonResultResponseDto<PaginatedList<GetUrgentNumberResponseDto>>> Handle(GetUrgentNumberQuery getUrgentNumberQuery, CancellationToken cancellationToken)
        {
            var filterModel = _requestBuilder.GetRequestBuilder(getUrgentNumberQuery.CommonRequest);
            return await _urgentNumberService.GetUrgentNumber(filterModel.GetFilters(), getUrgentNumberQuery.CommonRequest, filterModel.GetSorts());
        }
    }
}
