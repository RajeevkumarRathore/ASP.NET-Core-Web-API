using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.ImportantNumber;
using DTO.Response;
using DTO.Response.ImportantNumber;

namespace Application.Abstraction.Services
{
    public interface IImportantNumberService
    {
        Task<CommonResultResponseDto<PaginatedList<GetAllImportantNumberResponseDto>>> GetAllImportantNumbers(string filterModel, ServerRowsRequest commonRequest,string getSort);
      
        Task<CommonResultResponseDto<CreateUpdateImportantNumberResponseDto>> CreateUpdateImportantNumber(CreateUpdateImportantNumberRequestDto createUpdateImportantNumberRequestDto);
       
        Task<CommonResultResponseDto<string>> DeleteImportantNumber(DeleteImportantNumberRequestDto deleteImportantNumberRequestDto);
        Task<CommonResultResponseDto<PaginatedList<GetAllImportantNumberResponseDto>>> GetImportantNumberById(string filterModel, ServerRowsRequest commonRequest, int id, string getSort);

    }
}
