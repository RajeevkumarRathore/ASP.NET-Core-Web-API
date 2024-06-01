using Application.Abstraction.Services;
using DTO.Request.Header;
using DTO.Response;
using DTO.Response.Contact;
using Mapster;
using MediatR;

namespace Application.Handler.Contact.Queries.GetSearchContacts
{
    public class GetSearchContactsQueryHandler : IRequestHandler<GetSearchContactsQuery, CommonResultResponseDto<List<ContactSearchResponse>>>
    {
        private readonly IContactService _contactService;
        public GetSearchContactsQueryHandler(IContactService contactService)
        {
            _contactService = contactService;
        }
        public async Task<CommonResultResponseDto<List<ContactSearchResponse>>> Handle(GetSearchContactsQuery getSearchContactsQuery, CancellationToken cancellationToken)
        {
            return await _contactService.SearchContacts(getSearchContactsQuery.Adapt<ContactSearchRequestDto>());
        }
    }
}
