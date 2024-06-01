using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.DispatchLocation;
using DTO.Response;
using DTO.Response.DispatchLocation;
using DTO.Response.Settings;

namespace Application.Abstraction.Services
{
    public interface IDispatchLocationService
    {
        Task<CommonResultResponseDto<PaginatedList<DispatchLocationsResponseDto>>> GetAllDispatchLocations(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<CommonResultResponseDto<CreateUpdateDispatchLocationResponseDto>> CreateUpdateDispatchLocation(CreateUpdateDispatchLocationRequestDto createUpdateDispatchLocationRequestDto);
        Task<CommonResultResponseDto<string>> DeleteDispatchLocation(int id);
        Task<CommonResultResponseDto<string>> UpdateIsBayStatus(UpdateIsBayStatusRequestDto updateIsBayStatusRequestDto);
        Task<CommonResultResponseDto<DispatchLocationRequestDto>> CallUrlsAccordingToType(DispatchLocationRequestDto dispatchLocationRequestDto);
    }
}
