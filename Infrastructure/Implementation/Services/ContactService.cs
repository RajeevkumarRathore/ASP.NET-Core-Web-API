using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.Contact;
using DTO.Request.Header;
using DTO.Response;
using DTO.Response.Contact;
using Helper;

namespace Infrastructure.Implementation.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository  _contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<CommonResultResponseDto<string>> CreateUpdateContact(ContactRequestDto contactRequestDto)
        {
            var createContact = await _contactRepository.CreateUpdateContact(contactRequestDto);
            if (createContact > 0)
                {
                    if (contactRequestDto.Id == 0)
                    {
                        return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Created }, null, 0);
                    }

                    else
                    {
                        return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Updated }, null  , 0);
                    }
                }

                else
                {
                    return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.Error }, null);
                }

        }

        public async Task<CommonResultResponseDto<PaginatedList<ContactResponseDto>>> GetAllContact(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            var (getAllContact, total) = await _contactRepository.GetAllContact(filterModel, commonRequest, getSort);
            return CommonResultResponseDto<PaginatedList<ContactResponseDto>>.Success(new string[] { ActionStatusHelper.Success },new PaginatedList<ContactResponseDto>(getAllContact, total));
        }
        public async Task<CommonResultResponseDto<List<ContactSearchResponse>>> SearchContacts(ContactSearchRequestDto contactSearchRequestDto)
        {
            var searchContacts = await _contactRepository.SearchContacts(contactSearchRequestDto);
            return CommonResultResponseDto<List<ContactSearchResponse>>.Success(new string[] { ActionStatusHelper.Success }, searchContacts);
        }

    }
}

