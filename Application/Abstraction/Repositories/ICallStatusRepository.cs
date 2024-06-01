using Application.Common.Dtos;
using Domain.Entities;
using DTO.Response.CallStatus;

namespace Application.Abstraction.Repositories
{
    public interface ICallStatusRepository
    {
        Task<(List<CallStatusResponseDto>, int)> GetAllCallStatus(string filterModel, ServerRowsRequest commonRequest, string getSort);

        Task<int> CreateUpdateCallStatus(CreateUpdateCallStatusRequestDto createUpdateCallStatusRequestDto);
        Task<int> GetCallStatusByName(string Name);
        Task<CallStatus> GetCallStatusById(int id);
        Task<bool> IsExistCallStatus(string name, int id = 0);
        Task<bool> DeleteCallStatus(int id);
    }
}
