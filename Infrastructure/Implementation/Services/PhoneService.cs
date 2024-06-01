using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Helpers;
using Application.Common.Response;
using DTO.Request.Header;
using DTO.Response;
using DTO.Response.Header;
using Helper;
using Newtonsoft.Json;

namespace Infrastructure.Implementation.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly IPhoneRepository _phoneRepository;
        public PhoneService(IPhoneRepository phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }

        public async Task<CommonResultResponseDto<PaginatedList<ChatHistoryDto>>> GetChatMessageHistory(GetChatAllRequestDto getChatAllRequestDto)
        {
            var (chat, total) = await _phoneRepository.GetChatMessageHistory(getChatAllRequestDto);
            return CommonResultResponseDto<PaginatedList<ChatHistoryDto>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<ChatHistoryDto>(chat, total), 0);
        }

        public async Task<CommonResultResponseDto<PaginatedList<ChatHistoryViewModel>>> GetGroupChat(ChatMessageHistoryRequestDto chatMessageHistoryRequestDto)
        {
            var (chat, total) = await _phoneRepository.GetGroupChat(chatMessageHistoryRequestDto);
            return CommonResultResponseDto<PaginatedList<ChatHistoryViewModel>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<ChatHistoryViewModel>(chat, total), 0);
        }

        public async Task<CommonResultResponseDto<IList<ChatMessageHistoryResponseDto>>> GetGroupChatByExpertisesId(string id)
        {
            var getGroupChatByExpertisesId = await _phoneRepository.GetGroupChatByExpertisesId(id);
            return CommonResultResponseDto<IList<ChatMessageHistoryResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, getGroupChatByExpertisesId);
        }

        public async Task<CommonResultResponseDto<PaginatedList<ChatHistoryViewModel>>> GetInternalChat(ChatMessageHistoryRequestDto chatMessageHistoryDtoRequest)
        {
            var (task, total) = await _phoneRepository.GetInternalChat(chatMessageHistoryDtoRequest);
            return CommonResultResponseDto<PaginatedList<ChatHistoryViewModel>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<ChatHistoryViewModel>(task, total), 0);
        }

        public async Task<CommonResultResponseDto<List<ChatMessageHistoryResponseDto>>> GetInternalChatByUserId(string userId, string createdBy)
        {
            var getPhoneHistory = await _phoneRepository.GetInternalChatByUserId(userId, createdBy);
            return CommonResultResponseDto<List<ChatMessageHistoryResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, getPhoneHistory);
        }

        public async Task<ChatHistoryViewModelRequestDto> GetAgencyChat(ChatMessageHistoryRequestDto chatMessageHistoryDtoRequest)
        {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, ConstantVariables.AGENCY_CHAT_URL + "/GetAllAgencies?agencyId=" + chatMessageHistoryDtoRequest.agencyId + "&startRow=" + chatMessageHistoryDtoRequest.startRow + "&endRow=" + chatMessageHistoryDtoRequest.endRow);
                request.Headers.Add("accept", "*/*");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var jsonContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ChatHistoryViewModelRequestDto>(jsonContent);
                return (result);
            
        }

        public async Task<IList<ChatMessageHistoryResponseDto>> GetAgencyChatById(string id)
        {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, ConstantVariables.AGENCY_CHAT_URL + "/GetAgencyChatById?agencyId=" + id);
                request.Headers.Add("accept", "*/*");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var jsonContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ChatMessageHistoryResponseDto>>(jsonContent);
                return (result);
           
        }
    }
}
