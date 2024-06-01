using Application.Common.Dtos;
using DTO.Request.GetAllText;
using DTO.Response.GetAllText;

namespace Application.Abstraction.Repositories
{
    public interface IShortTextMessageRepository
    {
        Task<(List<GetAllTextResponseDto>, int)> GetAllText(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<bool> DeleteTextMessage(DeleteTextMessageRequestDto deleteTextMessageRequestDto);
        Task<int> CreateUpdateTextMessage(CreateUpdateTextMessageRequestDto createUpdateTextMessageRequestDto);
        Task<bool> IsExistTextMessage(string Name, int id = 0);
    }
}
