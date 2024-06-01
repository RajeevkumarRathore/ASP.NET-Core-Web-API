using Application.Common.Dtos;
using Domain.Entities;
using DTO.Request.Contact;
using DTO.Request.Header;
using DTO.Response.Contact;

namespace Application.Abstraction.Repositories
{
    public interface IContactRepository
    {
        Task<(List<ContactResponseDto>, int)> GetAllContact(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<int> CreateUpdateContact(ContactRequestDto contactRequestDto);
        Task<Contacts> GetContactById(int Id);
        Task<List<ContactSearchResponse>> SearchContacts(ContactSearchRequestDto contactSearchRequestDto);
    }
}
