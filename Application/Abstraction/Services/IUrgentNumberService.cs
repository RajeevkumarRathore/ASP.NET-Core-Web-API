using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using DTO.Request.UrgentNumber;
using DTO.Response.UrgentNumber;

namespace Application.Abstraction.Services
{
    public   interface IUrgentNumberService
    {
        Task<CommonResultResponseDto<PaginatedList<GetUrgentNumberResponseDto>>> GetUrgentNumber(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<CommonResultResponseDto<string>> CreateUpdateUrgentNumber(CreateUpdateUrgentNumberRequestDto createUpdateUrgentNumberRequestDto);
        Task<CommonResultResponseDto<string>> DeleteUrgentNumber(int id);
    }
}
