using DTO.Request.Header;
using DTO.Response;
using DTO.Response.Header;

namespace Application.Abstraction.Repositories
{
    public interface IPhoneRepository
    {
        Task<(List<ChatHistoryDto>, int)> GetChatMessageHistory(GetChatAllRequestDto getChatAllRequestDto);
        Task<(List<ChatHistoryViewModel>,int)> GetGroupChat(ChatMessageHistoryRequestDto chatMessageHistoryRequestDto);
        Task<IList<ChatMessageHistoryResponseDto>> GetGroupChatByExpertisesId(string id);
        Task<List<ChatMessageHistoryResponseDto>> GetInternalChatByUserId(string userId, string createdBy);
        Task<(List<ChatHistoryViewModel>, int)> GetInternalChat(ChatMessageHistoryRequestDto chatMessageHistoryDtoRequest);
    }
}
