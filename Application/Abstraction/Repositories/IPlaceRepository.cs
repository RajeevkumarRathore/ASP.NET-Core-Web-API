using Application.Common.Dtos;
using DTO.Request.Places;
using DTO.Response.Places;


namespace Application.Abstraction.Repositories
{
    public interface IPlaceRepository
    {
        Task<(List<GetAllPlacesResponseDto>, int)> GetAllPlaces(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<int> CreateUpdatePlace(CreateUpdatePlaceRequestDto createUpdatePlaceRequestDto);
        Task<bool> DeletePlace(DeletePlaceRequestDto deletePlaceRequestDto);
        Task<bool> IsExistPlace(string Name, int id = 0);
    }
}
