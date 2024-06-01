using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.ContactPerson;
using DTO.Response;
using DTO.Response.ContactPerson;



namespace Application.Abstraction.Services
{
    public interface IContactPersonService
    {
        Task<CommonResultResponseDto<PaginatedList<GetAllContactPersonResponseDto>>> GetAllContactPerson(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<CommonResultResponseDto<string>> DeleteContactPerson(DeleteContactPersonRequestDto deleteContactPersonRequestDto);
        Task<CommonResultResponseDto<string>> CreateUpdateContactPerson(CreateUpdateContactPersonRequestDto createUpdateContactPersonRequestDto);
    }
}
