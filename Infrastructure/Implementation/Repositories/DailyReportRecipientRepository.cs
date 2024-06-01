using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Application.Common.Dtos;
using Dapper;
using DTO.Request.DailyReportRecipient;
using DTO.Response.DailyReportRecipient;
using System.Data;

namespace Infrastructure.Implementation.Repositories
{
    public class DailyReportRecipientRepository : IDailyReportRecipientRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;

        public DailyReportRecipientRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;

        }

        public async Task<int> CreateUpdateDailyReportRecipient(CreateUpdateDailyReportRecipientRequestDto createUpdateDailyReportRecipientRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_CreateUpdateDailyReportRecipient",
         _parameterManager.Get("@Id", createUpdateDailyReportRecipientRequestDto.Id),
         _parameterManager.Get("@FirstName", createUpdateDailyReportRecipientRequestDto.FirstName),
         _parameterManager.Get("@LastName", createUpdateDailyReportRecipientRequestDto.LastName),
         _parameterManager.Get("@Email", createUpdateDailyReportRecipientRequestDto.Email),
         _parameterManager.Get("@IsDailyRecipient", createUpdateDailyReportRecipientRequestDto.IsDailyRecipient),
         _parameterManager.Get("@IsWeeklyRecipient", createUpdateDailyReportRecipientRequestDto.IsWeeklyRecipient));
        }

        public async Task<bool> DeleteDailyReportRecipient(DeleteDailyReportRecipientRequestDto deleteDailyReportRecipientRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_DeleteDailyReportRecipient",
           _parameterManager.Get("@Id", deleteDailyReportRecipientRequestDto.Id));
        }

        public async Task<(List<GetAllDailyReportRecipientResponseDto>, int)> GetAllDailyReportRecipient(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            List<GetAllDailyReportRecipientResponseDto> dailyReport;
            int total = 0;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
            "usp_hatzalah_GetAllDailyReportRecipient", _dbContext.GetDapperDynamicParameters
            (_parameterManager.Get("@StartRow", commonRequest.StartRow),
              _parameterManager.Get("@EndRow", commonRequest.EndRow),
              _parameterManager.Get("@FilterModel", filterModel),
              _parameterManager.Get("@OrderBy", getSort),
              _parameterManager.Get("@SearchText", commonRequest.SearchText)
            ),
            commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                dailyReport = result.Read<GetAllDailyReportRecipientResponseDto>().ToList();
                dbConnection.Close();
            }
            return (dailyReport, total);
        }

        public async Task<bool> IsExistDailyReportRecipient(string name, int id = 0)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_IsExistDailyReportRecipient",
               _parameterManager.Get("@Id", id),
             _parameterManager.Get("@Name", name));
        }
    }
}
