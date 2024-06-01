using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.Accesses;
using DTO.Response;
using DTO.Response.Accesses;

namespace Application.Abstraction.Services
{
    public interface IAccessesServices
    {
        Task<CommonResultResponseDto<PaginatedList<AccessesResponseDto>>> GetAllAccesses(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<CommonResultResponseDto<string>> CreateUpdateAccesses(CreateUpdateAccessesRequestDto createUpdateAccessesRequestDto);
        Task<CommonResultResponseDto<string>> DeleteAccess(int id);
    }
}
