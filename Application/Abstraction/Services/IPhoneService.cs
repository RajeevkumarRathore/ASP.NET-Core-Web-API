using Application.Common.Response;
using DTO.Request.Header;
using DTO.Response;
using DTO.Response.Header;

namespace Application.Abstraction.Services
{
    public interface IPhoneService
    {
        Task<CommonResultResponseDto<PaginatedList<ChatHistoryDto>>> GetChatMessageHistory(GetChatAllRequestDto getChatAllRequestDto);
        Task<CommonResultResponseDto<PaginatedList<ChatHistoryViewModel>>> GetGroupChat(ChatMessageHistoryRequestDto chatMessageHistoryRequestDto);
        Task<CommonResultResponseDto<IList<ChatMessageHistoryResponseDto>>> GetGroupChatByExpertisesId(string id);
        Task<CommonResultResponseDto<List<ChatMessageHistoryResponseDto>>> GetInternalChatByUserId(string userId, string createdBy);
        Task<CommonResultResponseDto<PaginatedList<ChatHistoryViewModel>>> GetInternalChat(ChatMessageHistoryRequestDto chatMessageHistoryDtoRequest);
        Task<ChatHistoryViewModelRequestDto> GetAgencyChat(ChatMessageHistoryRequestDto chatMessageHistoryDtoRequest);
        Task<IList<ChatMessageHistoryResponseDto>> GetAgencyChatById(string id);


    }
}
