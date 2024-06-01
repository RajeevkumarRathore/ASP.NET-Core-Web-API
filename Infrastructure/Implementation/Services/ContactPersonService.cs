using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.ContactPerson;
using DTO.Response;
using DTO.Response.ContactPerson;
using Helper;

namespace Infrastructure.Implementation.Services
{
    public class ContactPersonService : IContactPersonService
    {
        private readonly IContactPersonRepository _contactPersonRepository;
        public ContactPersonService(IContactPersonRepository contactPersonRepository)
        {
            _contactPersonRepository = contactPersonRepository;
        }

        public async Task<CommonResultResponseDto<string>> CreateUpdateContactPerson(CreateUpdateContactPersonRequestDto createUpdateContactPersonRequestDto)
        {
            var returnvalue = await _contactPersonRepository.IsExistContactPerson(createUpdateContactPersonRequestDto.ContactPersonName, createUpdateContactPersonRequestDto.Id);
            if (returnvalue == true)
            {
                return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.IsExistName }, null);
            }
            else
            {
                var number = await _contactPersonRepository.CreateUpdateContactPerson(createUpdateContactPersonRequestDto);

                if (number == 0)
                {
                    return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Created }, null, 0);
                }

                else
                {
                    return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Updated }, null, 0);
                }
            }
        }

        public async Task<CommonResultResponseDto<string>> DeleteContactPerson(DeleteContactPersonRequestDto deleteContactPersonRequestDto)
        {

            try
            {
                bool Id = await _contactPersonRepository.DeleteContactPerson(deleteContactPersonRequestDto);
                if (Id)
                {
                    return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Deleted }, null, 0);
                }
                else
                {
                    return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.Error }, null);
                }
            }
            catch
            {
                return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.Error }, null);
            }
        }

        public async Task<CommonResultResponseDto<PaginatedList<GetAllContactPersonResponseDto>>> GetAllContactPerson(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            var (text, total) = await _contactPersonRepository.GetAllContactPerson(filterModel, commonRequest, getSort);
            return CommonResultResponseDto<PaginatedList<GetAllContactPersonResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<GetAllContactPersonResponseDto>(text, total), 0);
        }
    }
}
