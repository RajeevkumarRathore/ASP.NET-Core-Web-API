using Application.Common.Dtos;
using Domain.Entities;
using DTO.Request.DispatchLocation;
using DTO.Response.DispatchLocation;

namespace Application.Abstraction.Repositories
{
    public interface IDispatchLocationRepository
    {
        Task<(List<DispatchLocationsResponseDto>, int)> GetAllDispatchLocations(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<int> CreateUpdateDispatchLocation(CreateUpdateDispatchLocationRequestDto createUpdateDispatchLocationRequestDto);
        Task<bool> DeleteDispatchLocation(int id);
        Task<bool> IsExistDispatchLocation(string name, int id = 0);
        Task<int> UpdateIsBayStatus(UpdateIsBayStatusRequestDto updateIsBayStatusRequestDto);
        Task<string> GetDispatchLocation(int id);
        Task<DispatchUrlSetting> GetBackUpAndLiveUrl(string purpose);

    }
}
