using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.Cities;
using DTO.Response;
using DTO.Response.Cities;


namespace Application.Abstraction.Services
{
    public interface ICitiesService
    {
        Task<CommonResultResponseDto<PaginatedList<GetAllCitiesResponseDto>>> GetAllCities(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<CommonResultResponseDto<CreateUpdateCitiesResponseDto>> CreateUpdateCities(CreateUpdateCitiesRequestDto createUpdateCitiesRequestDto);
        Task<CommonResultResponseDto<string>> DeleteCities(DeleteCitiesRequestDto deleteCitiesRequestDto);
        Task<CommonResultResponseDto<IList<GetCitiesResponseDto>>> GetCities();
    }
}
