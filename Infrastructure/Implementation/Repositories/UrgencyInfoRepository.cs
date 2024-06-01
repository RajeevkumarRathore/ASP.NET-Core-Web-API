using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Application.Common.Dtos;
using Dapper;
using DTO.Request.UrgencyInfo;
using DTO.Response.UrgencyInfo;
using System.Data;

namespace Infrastructure.Implementation.Repositories
{
    public class UrgencyInfoRepository : IUrgencyInfoRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;
        public UrgencyInfoRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;
        }


        public async Task<(List<UrgencyInfoResponseDto>, int)> GetAllUrgencyInfo(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            List<UrgencyInfoResponseDto> urgencyInfo;
            int total = 0;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
            "usp_hatzalah_GetAllUrgencyInfo", _dbContext.GetDapperDynamicParameters
            (_parameterManager.Get("@StartRow", commonRequest.StartRow),
              _parameterManager.Get("@EndRow", commonRequest.EndRow),
              _parameterManager.Get("@FilterModel", filterModel),
              _parameterManager.Get("@OrderBy", getSort),
              _parameterManager.Get("@SearchText", commonRequest.SearchText)
            ),
            commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                urgencyInfo = result.Read<UrgencyInfoResponseDto>().ToList();
                dbConnection.Close();
            }
            return (urgencyInfo, total);
        }

        public async Task<int> CreateUpdateUrgencyInfo(CreateUpdateUrgencyInfoRequestDto createUpdateUrgencyInfoRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_CreateUpdateUrgencyInfo",
            _parameterManager.Get("@Id", createUpdateUrgencyInfoRequestDto.Id),
            _parameterManager.Get("@UrgencyInfoName", createUpdateUrgencyInfoRequestDto.UrgencyInfoName),
            _parameterManager.Get("@UrgencyInfoType", createUpdateUrgencyInfoRequestDto.UrgencyInfoType),
            _parameterManager.Get("@Unit", createUpdateUrgencyInfoRequestDto.Unit),
            _parameterManager.Get("@Als", createUpdateUrgencyInfoRequestDto.Als),
            _parameterManager.Get("@Bus", createUpdateUrgencyInfoRequestDto.Bus),
            _parameterManager.Get("@IsPriority", createUpdateUrgencyInfoRequestDto.IsPriority),
            _parameterManager.Get("@UrgencyInfoCategoryId", createUpdateUrgencyInfoRequestDto.UrgencyInfoCategoryId)
            );
        }

        public async Task<bool> DeleteUrgencyInfo(int id)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_DeleteUrgencyInfo",
          _parameterManager.Get("@Id", id));
        }

        public async Task<bool> IsExistUrgencyInfo(string name, int id = 0)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_IsExistUrgencyInfo",
            _parameterManager.Get("@Id", id),
            _parameterManager.Get("@Name", name));
        }
    }
}
