using Application.Common.Dtos;
using DTO.Request.ImportantNumber;
using DTO.Response.ImportantNumber;

namespace Application.Abstraction.Repositories
{
    public interface IImportantNumberRepository
    {
        Task<(List<GetAllImportantNumberResponseDto>, int)> GetAllImportantNumbers(string filterModel, ServerRowsRequest commonRequest,string getSort);
       
        Task<int> CreateUpdateImportantNumber(CreateUpdateImportantNumberRequestDto  createUpdateImportantNumberRequestDto);
       
        Task<bool> DeleteImportantNumber(DeleteImportantNumberRequestDto deleteImportantNumberRequestDto);
        Task<bool> IsExistImportantNumber(string Name, int id = 0);
        Task<(List<GetAllImportantNumberResponseDto>, int)> GetImportantNumberById(string filterModel, ServerRowsRequest commonRequest, int id, string getSort);

    }
}
