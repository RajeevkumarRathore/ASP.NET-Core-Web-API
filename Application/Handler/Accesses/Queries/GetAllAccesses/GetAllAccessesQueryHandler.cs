using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;
using Application.Common.Response;
using DTO.Response;
using DTO.Response.Accesses;
using MediatR;

namespace Application.Handler.Accesses.Queries.GetAllAccesses
{
    public class GetAllAccessesQueryHandler : IRequestHandler<GetAllAccessesQuery, CommonResultResponseDto<PaginatedList<AccessesResponseDto>>>
    {
        private readonly IAccessesServices _accessesServices;
        private readonly IRequestBuilder _requestBuilder;
        public GetAllAccessesQueryHandler(IAccessesServices accessesServices, IRequestBuilder requestBuilder)
        {
            _accessesServices = accessesServices;
            _requestBuilder = requestBuilder;
        }
        public async Task<CommonResultResponseDto<PaginatedList<AccessesResponseDto>>> Handle(GetAllAccessesQuery getAllAccessesQuery, CancellationToken cancellationToken)
        {
            var filterModel = _requestBuilder.GetRequestBuilder(getAllAccessesQuery.CommonRequest);
            return await _accessesServices.GetAllAccesses(filterModel.GetFilters(), getAllAccessesQuery.CommonRequest, filterModel.GetSorts());
        }
    }
}
