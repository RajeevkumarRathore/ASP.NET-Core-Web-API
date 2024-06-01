using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.GetAllText;
using DTO.Response;
using DTO.Response.GetAllText;


namespace Application.Abstraction.Services
{
    public interface IShortTextMessageService
    {
        Task<CommonResultResponseDto<PaginatedList<GetAllTextResponseDto>>> GetAllText(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<CommonResultResponseDto<string>> DeleteTextMessage(DeleteTextMessageRequestDto deleteTextMessageRequestDto);
        Task<CommonResultResponseDto<string>> CreateUpdateTextMessage(CreateUpdateTextMessageRequestDto createUpdateTextMessageRequestDto);
    }
}
