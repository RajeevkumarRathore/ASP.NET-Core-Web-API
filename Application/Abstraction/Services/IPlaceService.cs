using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using DTO.Response.Places;
using DTO.Request.Places;

namespace Application.Abstraction.Services
{
    public interface IPlaceService
    {
        Task<CommonResultResponseDto<PaginatedList<GetAllPlacesResponseDto>>> GetAllPlaces(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<CommonResultResponseDto<CreateUpdatePlaceResponseDto>> CreateUpdatePlace(CreateUpdatePlaceRequestDto createUpdatePlaceRequestDto);
        Task<CommonResultResponseDto<string>> DeletePlace(DeletePlaceRequestDto deletePlaceRequestDto);
    }
}
