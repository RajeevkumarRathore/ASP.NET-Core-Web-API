using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using DTO.Request.Areas;
using DTO.Response.Areas;

namespace Application.Abstraction.Services
{
    public interface IAreasService
    {
        Task<CommonResultResponseDto<PaginatedList<GetAllAreasResponseDto>>> GetAllAreas(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<CommonResultResponseDto<CreateUpdateAreasResponseDto>> CreateUpdateAreas(CreateUpdateAreasRequestDto createUpdateAreasRequestDto);
        Task<CommonResultResponseDto<string>> DeleteAreas(DeleteAreasRequestDto deleteAreasRequestDto);
        Task<CommonResultResponseDto<IList<GetAreasResponseDto>>> GetAreas();
    }
}
