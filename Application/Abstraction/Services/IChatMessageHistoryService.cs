using DTO.Request.Header;
using DTO.Response;
using DTO.Response.Header;

namespace Application.Abstraction.Services
{
    public interface IChatMessageHistoryService
    {
        Task<CommonResultResponseDto<List<ChatMessageHistoryResponseDto>>> GetChatMessageHistoryByUserId(string chatUserId, string phone);
        Task<CommonResultResponseDto<ChatRequestDto>> AddChatMessage(AddChatRequestDto chatRequest);
    }
}
