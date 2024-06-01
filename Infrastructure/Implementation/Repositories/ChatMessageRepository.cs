using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Dapper;
using Domain.Entities;
using DTO.Request.Header;
using DTO.Response.Header;
using System.Data;

namespace Infrastructure.Implementation.Repositories
{
    public class ChatMessageRepository : IChatMessageRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;

        public ChatMessageRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;

        }
        public async Task<List<ChatMessageHistoryResponseDto>> GetChatMessageHistoryByUserId(string chatUserId, string phone)
        {
            List<ChatMessageHistoryResponseDto> ChatMessageHistory;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync("usp_hatzalah_GetChatMessageHistoryByUserId", _dbContext.GetDapperDynamicParameters(
                _parameterManager.Get("UserId", chatUserId),
                _parameterManager.Get("Phone", phone)),
                    commandType: CommandType.StoredProcedure);
                ChatMessageHistory = result.Read<ChatMessageHistoryResponseDto>().ToList();
                dbConnection.Close();
            }
            return (ChatMessageHistory);
        }
        public async Task<ChatMessageHistory> AddChatMessageHistory(AddChatRequestDto chatRequest)
        {
            return await _dbContext.ExecuteStoredProcedure<ChatMessageHistory>("usp_hatzalah_AddChatMessageHistory",
            _parameterManager.Get("@CreatedBy", chatRequest.CreatedBy),
            _parameterManager.Get("@MessageCreateOn", chatRequest.MessageCreateOn),
            _parameterManager.Get("@MessageId", chatRequest.MessageId),
            _parameterManager.Get("@MessageType", chatRequest.MessageType),
            _parameterManager.Get("@PhoneNumber", chatRequest.PhoneNumber),
            _parameterManager.Get("@ContactId", chatRequest.ContactId),
            _parameterManager.Get("@MemberId", chatRequest.MemberId),
            _parameterManager.Get("@TextMessage", chatRequest.TextMessage),
            _parameterManager.Get("@IsRead", chatRequest.IsRead),
            _parameterManager.Get("@ClientId", chatRequest.selectedClientId),
            _parameterManager.Get("@TextMessageMemberAdditionsId", chatRequest.textMessageMemberAdditionsId),
            _parameterManager.Get("@MessageId", chatRequest.MessageId));
        }
    }
}
