using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Application.Common.Dtos;
using Dapper;
using DTO.Request.GetAllText;
using DTO.Response.GetAllText;
using System.Data;

namespace Infrastructure.Implementation.Repositories
{
    public class ShortTextMessageRepository : IShortTextMessageRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;
        public ShortTextMessageRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;
        }

        public async Task<int> CreateUpdateTextMessage(CreateUpdateTextMessageRequestDto createUpdateTextMessageRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_CreateUpdateTextMessage",
         _parameterManager.Get("@Id", createUpdateTextMessageRequestDto.Id),
         _parameterManager.Get("@ShortText", createUpdateTextMessageRequestDto.ShortText),
         _parameterManager.Get("@FullText", createUpdateTextMessageRequestDto.FullText),
         _parameterManager.Get("@Type", createUpdateTextMessageRequestDto.Type));
        }

        public async Task<bool> DeleteTextMessage(DeleteTextMessageRequestDto deleteTextMessageRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_DeleteTextMessage",
           _parameterManager.Get("@Id", deleteTextMessageRequestDto.Id));
        }

        public async  Task<(List<GetAllTextResponseDto>, int)> GetAllText(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            List<GetAllTextResponseDto> text;
            int total = 0;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
            "usp_hatzalah_GetAllText", _dbContext.GetDapperDynamicParameters
            (_parameterManager.Get("@StartRow", commonRequest.StartRow),
              _parameterManager.Get("@EndRow", commonRequest.EndRow),
              _parameterManager.Get("@FilterModel", filterModel),
              _parameterManager.Get("@OrderBy", getSort),
              _parameterManager.Get("@SearchText", commonRequest.SearchText)
            ),
            commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                text = result.Read<GetAllTextResponseDto>().ToList();
                dbConnection.Close();
            }
            return (text, total);
        }

        public async Task<bool> IsExistTextMessage(string Name, int id = 0)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_IsExistTextMessage",
               _parameterManager.Get("@Id", id),
               _parameterManager.Get("@Name", Name));
        }
    }
    
}
