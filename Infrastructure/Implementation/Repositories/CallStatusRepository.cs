using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Application.Common.Dtos;
using Dapper;
using Domain.Entities;
using DTO.Response.CallStatus;
using System.Data;

namespace Infrastructure.Implementation.Repositories
{
    public class CallStatusRepository : ICallStatusRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;
        public CallStatusRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;
        }

        public async Task<(List<CallStatusResponseDto>, int)> GetAllCallStatus(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            List<CallStatusResponseDto> callStatus;
            int total = 0;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
            "usp_hatzalah_GetAllCallStatus", _dbContext.GetDapperDynamicParameters
            (_parameterManager.Get("@StartRow", commonRequest.StartRow),
              _parameterManager.Get("@EndRow", commonRequest.EndRow),
              _parameterManager.Get("@FilterModel", filterModel),
              _parameterManager.Get("@OrderBy", getSort),
              _parameterManager.Get("@SearchText", commonRequest.SearchText)
            ),
            commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                callStatus = result.Read<CallStatusResponseDto>().ToList();
                dbConnection.Close();
            }
            return (callStatus, total);
        }

        public async Task<bool> IsExistCallStatus(string name, int id = 0)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_IsExistCallStatus",
             _parameterManager.Get("@Id", id),
             _parameterManager.Get("@Name", name));
        }

        public async Task<int> CreateUpdateCallStatus(CreateUpdateCallStatusRequestDto createUpdateCallStatusRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_CreateUpdateCallStatus",
           _parameterManager.Get("@Id", createUpdateCallStatusRequestDto.Id),
            _parameterManager.Get("@CallStatusName", createUpdateCallStatusRequestDto.Name),
            _parameterManager.Get("@Color", createUpdateCallStatusRequestDto.Color),
            _parameterManager.Get("@RowNumber", createUpdateCallStatusRequestDto.RowNumber)
           );
        }

        public async Task<int> GetCallStatusByName(string Name)
        {
            return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_GetCallStatusByName",
         _parameterManager.Get("@CallStatusName", Name));
        }

        public async Task<CallStatus> GetCallStatusById(int id)
        {
            return await _dbContext.ExecuteStoredProcedure<CallStatus>("usp_hatzalah_GetCallStatusById",
         _parameterManager.Get("@Id", id));
        }

        public async Task<bool> DeleteCallStatus(int id)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_DeleteCallStatus",
         _parameterManager.Get("@Id", id));
        }
    }
}
