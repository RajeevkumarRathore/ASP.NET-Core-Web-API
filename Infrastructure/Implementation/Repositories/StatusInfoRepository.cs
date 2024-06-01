using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Application.Common.Dtos;
using Dapper;
using Domain.Entities;
using DTO.Request.StatusInfo;
using DTO.Response.StatusInfos;
using System.Data;

namespace Infrastructure.Implementation.Repositories
{
    public class StatusInfoRepository : IStatusInfoRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;
        public StatusInfoRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;
        }
        public async Task<(List<StatusInfosResponseDto>, int)> GetAllStatusInfo(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            List<StatusInfosResponseDto> statusInfo;
            int total = 0;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
            "usp_hatzalah_GetAllStatusInfo", _dbContext.GetDapperDynamicParameters
            (_parameterManager.Get("@StartRow", commonRequest.StartRow),
              _parameterManager.Get("@EndRow", commonRequest.EndRow),
              _parameterManager.Get("@FilterModel", filterModel),
              _parameterManager.Get("@OrderBy", getSort),
              _parameterManager.Get("@SearchText", commonRequest.SearchText)
            ),
            commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                statusInfo = result.Read<StatusInfosResponseDto>().ToList();
                dbConnection.Close();
            }
            return (statusInfo, total);
        }
        public async Task<(List<ApprovalMemberResponseDto>,int)> GetAllApprovalMembers(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            List<ApprovalMemberResponseDto> approvalMembers;
            int total = 0;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
            "usp_hatzalah_GetAllApprovalMembers", _dbContext.GetDapperDynamicParameters
            (_parameterManager.Get("@StartRow", commonRequest.StartRow),
              _parameterManager.Get("@EndRow", commonRequest.EndRow),
              _parameterManager.Get("@FilterModel", filterModel),
              _parameterManager.Get("@OrderBy", getSort),
              _parameterManager.Get("@SearchText", commonRequest.SearchText)
            ),
            commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                approvalMembers = result.Read<ApprovalMemberResponseDto>().ToList();
                dbConnection.Close();
            }
            return (approvalMembers, total);
        }

        public async Task<string> UpdateNeedsApprovalStatus(UpdateNeedsApprovalStatusRequestDto updateNeedsApprovalRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<string>("usp_hatzalah_UpdateNeedsApprovalStatus",
           _parameterManager.Get("@Id", updateNeedsApprovalRequestDto.Id),
           _parameterManager.Get("@NeedsApproval", updateNeedsApprovalRequestDto.NeedsApproval)
           );
        }

        public async Task<bool> CreateUpdateApprovalMembers(ApprovalMemberRequestDto approvalMemberRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_CreateUpdateApprovalMembers",
           _parameterManager.Get("@ApprovalMemberName", approvalMemberRequestDto.Name),
            _parameterManager.Get("@Id", approvalMemberRequestDto.Id?.ToString())
           );
        }

        public async Task<int> CreateUpdateStatusInfo(CreateUpdateStatusInfoRequestDto createUpdateStatusInfoRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_CreateUpdateStatusInfo",
            _parameterManager.Get("@Id", createUpdateStatusInfoRequestDto.Id),
            _parameterManager.Get("@StatusInfoName", createUpdateStatusInfoRequestDto.StatusInfoName),
            _parameterManager.Get("@InfoTypeId", createUpdateStatusInfoRequestDto.InfoTypeId)
            );
        }

        public async Task<bool> DeleteApprovalMember(Guid id)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_DeleteApprovalMember",
          _parameterManager.Get("@Id", id.ToString()));
        }

        public async Task<Guid> GetApprovalMemberByName(string Name)
        {
            return await _dbContext.ExecuteStoredProcedure<Guid>("usp_hatzalah_GetApprovalMemberByName",
          _parameterManager.Get("@ApprovalMemberName", Name));
        }

        public async Task<ApprovalMemberResponseDto> GetApprovalMemberById(Guid? id)
        {
            return await _dbContext.ExecuteStoredProcedure<ApprovalMemberResponseDto>("usp_hatzalah_GetApprovalMemberById",
           _parameterManager.Get("@Id", id.ToString()));
        }

        public async Task<bool> DeleteStatusInfo(int id)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_DeleteStatusInfo",
         _parameterManager.Get("@Id", id));
        }

        public  async Task<bool> IsExistStatusInfo(string name, int id = 0)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_IsExistStatusInfo",
              _parameterManager.Get("@Id", id),
              _parameterManager.Get("@Name", name));
        }

        public async Task<bool> IsExistApprovalMember(string name, Guid? id)
        
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_IsExistApprovalMember",
               _parameterManager.Get("@Id", id?.ToString() ?? Guid.Empty.ToString()),
               _parameterManager.Get("@Name", name));
        }
    }
}
