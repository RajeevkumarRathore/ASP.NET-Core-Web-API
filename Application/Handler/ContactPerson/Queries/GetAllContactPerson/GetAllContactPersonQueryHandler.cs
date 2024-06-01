using Application.Common.Response;
using DTO.Response;
using MediatR;
using DTO.Response.ContactPerson;
using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;

namespace Application.Handler.ContactPerson.Queries.GetAllContactPerson
{
    public class GetAllContactPersonQueryHandler : IRequestHandler<GetAllContactPersonQuery, CommonResultResponseDto<PaginatedList<GetAllContactPersonResponseDto>>>
    {
        private readonly IContactPersonService _contactPersonService;
        private readonly IRequestBuilder _requestBuilder;
        public GetAllContactPersonQueryHandler(IContactPersonService contactPersonService, IRequestBuilder requestBuilder)
        {
            _contactPersonService = contactPersonService;
            _requestBuilder = requestBuilder;
        }
        public async  Task<CommonResultResponseDto<PaginatedList<GetAllContactPersonResponseDto>>> Handle(GetAllContactPersonQuery getAllContactPersonQuery, CancellationToken cancellationToken)
        {
            var filterModel = _requestBuilder.GetRequestBuilder(getAllContactPersonQuery.CommonRequest);
            return await _contactPersonService.GetAllContactPerson(filterModel.GetFilters(), getAllContactPersonQuery.CommonRequest, filterModel.GetSorts());
        }
    }
}
