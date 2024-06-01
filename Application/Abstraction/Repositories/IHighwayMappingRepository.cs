using Application.Common.Dtos;
using DTO.Request.HighwayMapping;
using DTO.Response.HighwayMapping;

namespace Application.Abstraction.Repositories
{
    public interface IHighwayMappingRepository
    {
        Task<(List<GetAllHighwayMappingResponseDto>, int)> GetAllHighwayMapping(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<int> CreateUpdateHighwayMapping(CreateUpdateHighwayMappingRequestDto createUpdateHighwayMappingRequestDto);
        Task<bool> DeleteHighwayMapping(DeleteHighwayMappingRequestDto deleteHighwayMappingRequestDto);
        Task<bool> IsExistHighwayMapping(string name, int id = 0);
        Task<IList<GetAllHighwayNameResponseDto>> GetAllHighwayName();
    }
}
