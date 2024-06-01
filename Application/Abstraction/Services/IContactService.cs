using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.Contact;
using DTO.Request.Header;
using DTO.Response;
using DTO.Response.Contact;

namespace Application.Abstraction.Services
{
    public interface IContactService
    {
        Task<CommonResultResponseDto<PaginatedList<ContactResponseDto>>> GetAllContact(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<CommonResultResponseDto<string>> CreateUpdateContact(ContactRequestDto contactRequestDto); 
        Task<CommonResultResponseDto<List<ContactSearchResponse>>> SearchContacts(ContactSearchRequestDto contactSearchRequestDto);

    }
}
