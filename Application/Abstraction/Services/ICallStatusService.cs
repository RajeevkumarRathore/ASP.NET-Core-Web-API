using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using DTO.Response.CallStatus;

namespace Application.Abstraction.Services
{
    public interface ICallStatusService
    {
        Task<CommonResultResponseDto<PaginatedList<CallStatusResponseDto>>> GetAllCallStatus(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<CommonResultResponseDto<string>> CreateUpdateCallStatus(CreateUpdateCallStatusRequestDto createUpdateCallStatusRequestDto);
        Task<CommonResultResponseDto<string>> DeleteCallStatus(int id);
    }
}
