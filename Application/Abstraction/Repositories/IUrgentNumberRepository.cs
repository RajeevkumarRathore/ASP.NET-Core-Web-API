using Application.Common.Dtos;
using DTO.Request.UrgentNumber;
using DTO.Response.UrgentNumber;

namespace Application.Abstraction.Repositories
{
    public interface IUrgentNumberRepository
    {
        Task<(List<GetUrgentNumberResponseDto>, int)> GetUrgentNumber(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<int> CreateUpdateUrgentNumber(CreateUpdateUrgentNumberRequestDto createUpdateUrgentNumberRequestDto);
        Task<bool> DeleteUrgentNumber(int id);
        Task<bool> IsExistUrgentNumber(string name, int id = 0);
    }
}
