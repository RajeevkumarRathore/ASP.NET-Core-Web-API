using Application.Common.Dtos;
using DTO.Request.BusSection;
using DTO.Response.BusSection;

namespace Application.Abstraction.Repositories
{
    public interface IBusSectionRepository
    {
       
        Task<(List<GetBusSectionResponseDto>, int)> GetBusSection(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<int> CreateUpdateBusSection(CreateUpdateBusSectionRequestDto createUpdateBusSectionRequestDto);
        Task<int> GetBusSectionByName(string name);
        Task<GetBusSectionResponseDto> GetBusSectionById(int id);
        Task<bool> IsExistBusSection(string name, int id = 0);
        Task<bool> DeleteBusSection(int id);
    }
}
