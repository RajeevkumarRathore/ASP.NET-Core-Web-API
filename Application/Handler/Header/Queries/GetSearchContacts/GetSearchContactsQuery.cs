using DTO.Response;
using DTO.Response.Contact;
using MediatR;
namespace Application.Handler.Contact.Queries.GetSearchContacts
{
    public class GetSearchContactsQuery : IRequest<CommonResultResponseDto<List<ContactSearchResponse>>>
    {
        public string searchText { get; set; }
        public bool IsFromChat { get; set; }
        public bool IsOnlyMember { get; set; }
        public bool isFromBria { get; set; }
        public bool alsoMembersFromContactSearch { get; set; }
    }
}
