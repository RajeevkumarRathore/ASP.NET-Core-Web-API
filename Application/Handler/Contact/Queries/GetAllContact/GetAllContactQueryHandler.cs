using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;
using Application.Common.Response;
using DTO.Response;
using DTO.Response.Contact;
using MediatR;

namespace Application.Handler.Contact.Queries.GetAllContact
{
    public class GetAllContactQueryHandler : IRequestHandler<GetAllContactQuery, CommonResultResponseDto<PaginatedList<ContactResponseDto>>>
    {
        private readonly IContactService _contactService;
        private readonly IRequestBuilder _requestBuilder;
        public GetAllContactQueryHandler(IContactService contactService, IRequestBuilder requestBuilder)
        {
            _contactService = contactService;
            _requestBuilder = requestBuilder;
        }
        public async Task<CommonResultResponseDto<PaginatedList<ContactResponseDto>>> Handle(GetAllContactQuery  getAllContactQuery, CancellationToken cancellationToken)
        {
            var filterModel = _requestBuilder.GetRequestBuilder(getAllContactQuery.CommonRequest);
            return await _contactService.GetAllContact(filterModel.GetFilters(), getAllContactQuery.CommonRequest, filterModel.GetSorts());
        }
    }
}
