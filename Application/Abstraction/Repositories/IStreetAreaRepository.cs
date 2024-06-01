using Application.Common.Dtos;
using DTO.Request.StreetArea;
using DTO.Response.StreetArea;


namespace Application.Abstraction.Repositories
{
    public interface IStreetAreaRepository
    {
        Task<(List<GetAllStreetAreaResponseDto>, int)> GetAllStreetArea(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<int> CreateUpdateStreetArea(CreateUpdateStreetAreaRequestDto createUpdateStreetAreaRequestDto);
        Task<bool> IsExistStreetArea(string Name, int id = 0);
        Task<bool> DeleteStreetArea(DeleteStreetAreaRequestDto deleteStreetAreaRequestDto);
    }
}
