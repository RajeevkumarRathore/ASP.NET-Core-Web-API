using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Dapper;
using DTO.Request.Header;
using DTO.Response;
using DTO.Response.Header;
using System.Data;

namespace Infrastructure.Implementation.Repositories
{
    public class PhoneRepository : IPhoneRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;
        public PhoneRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;
        }
        public async Task<(List<ChatHistoryDto>, int)> GetChatMessageHistory(GetChatAllRequestDto getChatAllRequestDto)
        {
            List<ChatHistoryDto> admin;
            int total;
            using (var dbConnection = _dbContext.GetDbConnection())
            {

                var result = await dbConnection.QueryMultipleAsync(
                   "usp_hatzalah_GetChatMessageHistory", _dbContext.GetDapperDynamicParameters
                  (_parameterManager.Get("@SearchText", getChatAllRequestDto.SearchText),
                  _parameterManager.Get("@StartRow", getChatAllRequestDto.StartRow),
                  _parameterManager.Get("@EndRow", getChatAllRequestDto.EndRow),
                  _parameterManager.Get("@IsMember", getChatAllRequestDto.IsMember)),

                  commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                admin = result.Read<ChatHistoryDto>().ToList();
                dbConnection.Close();
            }
            return (admin, total);
        }

        public async Task<(List<ChatHistoryViewModel>, int)> GetGroupChat(ChatMessageHistoryRequestDto chatMessageHistoryRequestDto)
        {
            List<ChatHistoryViewModel> admin;
            int total;
            using (var dbConnection = _dbContext.GetDbConnection())
            {

                var result = await dbConnection.QueryMultipleAsync(
                   "Usp_hatzalah_GetGroupChat", _dbContext.GetDapperDynamicParameters
                  (_parameterManager.Get("@StartRow", chatMessageHistoryRequestDto.startRow),
                  _parameterManager.Get("@EndRow", chatMessageHistoryRequestDto.endRow)),

                  commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                admin = result.Read<ChatHistoryViewModel>().ToList();
                dbConnection.Close();
            }
            return (admin, total);
        }

        public async Task<IList<ChatMessageHistoryResponseDto>> GetGroupChatByExpertisesId(string id)
        {
            return await _dbContext.ExecuteStoredProcedureList<ChatMessageHistoryResponseDto>("Usp_hatzalah_GetGroupChatByExpertisesId",
       _parameterManager.Get("@ExpertisesId", id));
        }
        public async Task<List<ChatMessageHistoryResponseDto>> GetInternalChatByUserId(string userId, string createdBy)
        {
            List<ChatMessageHistoryResponseDto> ChatMessageHistory;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync("usp_hatzalah_GetInternalChatByUserId", _dbContext.GetDapperDynamicParameters(
                _parameterManager.Get("@UserId", userId),
                _parameterManager.Get("@CreatedBy", createdBy)),
                    commandType: CommandType.StoredProcedure);
                ChatMessageHistory = result.Read<ChatMessageHistoryResponseDto>().ToList();
                dbConnection.Close();
            }
            return (ChatMessageHistory);
        }

        public async Task<(List<ChatHistoryViewModel>, int)> GetInternalChat(ChatMessageHistoryRequestDto chatMessageHistoryDtoRequest)
        {
            List<ChatHistoryViewModel> users;
            int total = 0;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
            "usp_hatzalah_GetInternalChat", _dbContext.GetDapperDynamicParameters
            (_parameterManager.Get("@UserId", chatMessageHistoryDtoRequest.userId),
              _parameterManager.Get("@StartRow", chatMessageHistoryDtoRequest.startRow),
              _parameterManager.Get("@EndRow", chatMessageHistoryDtoRequest.endRow)
            ),
            commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                users = result.Read<ChatHistoryViewModel>().ToList();
                dbConnection.Close();
            }
            return (users, total);
        }
    }
}
