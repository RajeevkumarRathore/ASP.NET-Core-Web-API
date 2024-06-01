using Application.Common.Dtos;
using DTO.Request.Areas;
using DTO.Response.Areas;

namespace Application.Abstraction.Repositories
{
    public interface IAreasRepository
    {
        Task<(List<GetAllAreasResponseDto>, int)> GetAllAreas(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<int> CreateUpdateAreas(CreateUpdateAreasRequestDto createUpdateAreasRequestDto);
        Task<bool> DeleteAreas(DeleteAreasRequestDto deleteAreasRequestDto);
        Task<bool> IsExistStreetArea(string name, int id = 0);
        Task<IList<GetAreasResponseDto>> GetAreas();

    }
}
