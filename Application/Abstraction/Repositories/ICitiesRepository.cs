using Application.Common.Dtos;
using DTO.Request.Cities;
using DTO.Response.Cities;


namespace Application.Abstraction.Repositories
{
    public interface ICitiesRepository
    {
        Task<(List<GetAllCitiesResponseDto>, int)> GetAllCities(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<int> CreateUpdateCities(CreateUpdateCitiesRequestDto createUpdateCitiesRequestDto);
        Task<bool> DeleteCities(DeleteCitiesRequestDto deleteCitiesRequestDto);
        Task<bool> IsExistCity(string name, int id = 0);
        Task<IList<GetCitiesResponseDto>> GetCities();

    }

}

