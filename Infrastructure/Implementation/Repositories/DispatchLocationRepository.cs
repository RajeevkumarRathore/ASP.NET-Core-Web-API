using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Application.Common.Dtos;
using Dapper;
using Domain.Entities;
using DTO.Request.DispatchLocation;
using DTO.Response.DispatchLocation;
using DTO.Response.Settings;
using System.Data;

namespace Infrastructure.Implementation.Repositories
{
    public class DispatchLocationRepository : IDispatchLocationRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;
        public DispatchLocationRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;
        }

        public async Task<(List<DispatchLocationsResponseDto>, int)> GetAllDispatchLocations(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            List<DispatchLocationsResponseDto> dispatchLocations;
            int total = 0;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
            "usp_hatzalah_GetAllDispatchLocations", _dbContext.GetDapperDynamicParameters
            (_parameterManager.Get("@StartRow", commonRequest.StartRow),
              _parameterManager.Get("@EndRow", commonRequest.EndRow),
              _parameterManager.Get("@FilterModel", filterModel),
              _parameterManager.Get("@OrderBy", getSort),
              _parameterManager.Get("@SearchText", commonRequest.SearchText)
            ),
            commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                dispatchLocations = result.Read<DispatchLocationsResponseDto>().ToList();
                dbConnection.Close();
            }
            return (dispatchLocations, total);
        }

        public async Task<int> CreateUpdateDispatchLocation(CreateUpdateDispatchLocationRequestDto createUpdateDispatchLocationRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_CreateUpdateDispatchLocation",
           _parameterManager.Get("@Id", createUpdateDispatchLocationRequestDto.Id),
           _parameterManager.Get("@LocationName", createUpdateDispatchLocationRequestDto.LocationName),
           _parameterManager.Get("@Code", createUpdateDispatchLocationRequestDto.Code),
           _parameterManager.Get("@IsBackup", createUpdateDispatchLocationRequestDto.IsBackup),
           _parameterManager.Get("@IsDelay", createUpdateDispatchLocationRequestDto.IsDelay),
           _parameterManager.Get("@IsCoordinator", createUpdateDispatchLocationRequestDto.IsCoordinator),
           _parameterManager.Get("@IsBay", createUpdateDispatchLocationRequestDto.IsBay)
           );
        }

        public async Task<bool> IsExistDispatchLocation(string name, int id = 0)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_IsExistDispatchLocation",
          _parameterManager.Get("@Id", id),
          _parameterManager.Get("@Name", name));
        }

        public async Task<bool> DeleteDispatchLocation(int id)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_DeleteDispatchLocation",
          _parameterManager.Get("@Id", id));
        }

        public async Task<int> UpdateIsBayStatus(UpdateIsBayStatusRequestDto updateIsBayStatusRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_UpdateIsBayStatus",
           _parameterManager.Get("@Id", updateIsBayStatusRequestDto.Id),
           _parameterManager.Get("@IsBay", updateIsBayStatusRequestDto.IsBay));
        }

        public async Task<string> GetDispatchLocation(int id)
        {
            return await _dbContext.ExecuteStoredProcedure<string>("usp_hatzalah_GetDispatchLocation",
          _parameterManager.Get("@Id", id));
        }

        public async Task<DispatchUrlSetting> GetBackUpAndLiveUrl(string purpose)
        {
            return await _dbContext.ExecuteStoredProcedure<DispatchUrlSetting>("usp_hatzalah_GetBackUpAndLiveUrl",
          _parameterManager.Get("@Purpose", purpose));
        }
    }
}
