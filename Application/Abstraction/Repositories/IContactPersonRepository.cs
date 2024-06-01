using Application.Common.Dtos;
using DTO.Request.ContactPerson;
using DTO.Response.ContactPerson;

namespace Application.Abstraction.Repositories
{
    public interface IContactPersonRepository
    {
        Task<(List<GetAllContactPersonResponseDto>, int)> GetAllContactPerson(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<bool> DeleteContactPerson(DeleteContactPersonRequestDto  deleteContactPersonRequestDto);
        Task<int> CreateUpdateContactPerson(CreateUpdateContactPersonRequestDto createUpdateContactPersonRequestDto);
        Task<bool> IsExistContactPerson(string Name, int id = 0);
    }
}
