using Application.Common.Dtos;
using DTO.Request.Accesses;
using DTO.Response.Accesses;

namespace Application.Abstraction.Repositories
{
    public interface IAccessesRepository
    {
        Task<(List<AccessesResponseDto>, int)> GetAllAccesses(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<int> CreateUpdateAccesses(CreateUpdateAccessesRequestDto createUpdateAccessesRequestDto);
        Task<int> GetAccessesByName(string name);
        Task<AccessesResponseDto> GetAccessesById(int id);
        Task<bool> IsExistAccesses(string name, int id = 0);
        Task<bool> DeleteAccess(int id);
    }
}
