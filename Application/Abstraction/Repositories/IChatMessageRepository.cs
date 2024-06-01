using Domain.Entities;
using DTO.Request.Header;
using DTO.Response.Header;

namespace Application.Abstraction.Repositories
{
    public interface IChatMessageRepository
    {
        Task<List<ChatMessageHistoryResponseDto>> GetChatMessageHistoryByUserId(string chatUserId, string phone);
        Task<ChatMessageHistory> AddChatMessageHistory(AddChatRequestDto chatRequest);

    }
}
