using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Application.Common.Dtos;
using Dapper;
using Domain.Entities;
using DTO.Request.AgencyPermission;
using DTO.Response.AgencyPermission;
using System.Data;

namespace Infrastructure.Implementation.Repositories
{
    public class AgencyPermissionRepository : IAgencyPermissionRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;

        public AgencyPermissionRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;

        }
        public async Task<List<AgencyModule>> GetAgencyModule()
        {
            List<AgencyModule> agencies;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync("usp_hatzalah_GetAgencyModule", _dbContext.GetDapperDynamicParameters(),
                    commandType: CommandType.StoredProcedure);
                agencies = result.Read<AgencyModule>().ToList();
                dbConnection.Close();
            }
            return (agencies);
        }

        public async Task<List<HeaderModule>> GetHeaderModule(int id)
        {
            List<HeaderModule> header;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync("usp_hatzalah_GetHeaderModule", _dbContext.GetDapperDynamicParameters(
                      _parameterManager.Get("@Id", id)
                    ),
                    commandType: CommandType.StoredProcedure);
                header = result.Read<HeaderModule>().ToList();
                dbConnection.Close();
            }
            return (header);
        }
        public async Task<UpdateAgencyPermissionRequestDto> UpdateAgencyPermission(UpdateAgencyPermissionRequestDto createAgencyPermissionByModuleRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<UpdateAgencyPermissionRequestDto>("usp_hatzalah_UpdateAgencyPermission",
            _parameterManager.Get("@AgencyPermissionId", createAgencyPermissionByModuleRequestDto.AgencyPermissionId),
            _parameterManager.Get("@IsSetPermission", createAgencyPermissionByModuleRequestDto.IsSetPermission));
        }

        public async Task<(List<GetAgencyPermissionByModuleIdResponseDto>, int)> GetAgencyPermissionByModuleId(string filterModel, ServerRowsRequest commonRequest, string getSort, int agencyModuleId)
        {
            List<GetAgencyPermissionByModuleIdResponseDto> Agency;
            int total = 0;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
                    "usp_hatzalah_GetAgencyPermissionByModuleId",
                    _dbContext.GetDapperDynamicParameters(
                        _parameterManager.Get("@StartRow", commonRequest?.StartRow ?? 0),
                        _parameterManager.Get("@EndRow", commonRequest?.EndRow ?? 0),
                        _parameterManager.Get("@FilterModel", filterModel ?? string.Empty),
                        _parameterManager.Get("@OrderBy", getSort ?? string.Empty),
                        _parameterManager.Get("@SearchText", commonRequest?.SearchText ?? string.Empty),
                        _parameterManager.Get("@AgencyModuleId", agencyModuleId)
                    ),
                    commandType: CommandType.StoredProcedure);                     
                    total = result.Read<int>().FirstOrDefault();                                               
                    Agency = result.Read<GetAgencyPermissionByModuleIdResponseDto>().ToList();
                    dbConnection.Close();
            }
            return (Agency, total);
        }

        public async Task<string> UpdateAgencyPermissionByModuleId(string agencyModulePermissionXML, int moduleId)
        {
            return await _dbContext.ExecuteStoredProcedure<string>("usp_hatzalah_UpdateAgencyPermissionByModuleId",
                    _parameterManager.Get("@AgencyModuleId", moduleId),
                  _parameterManager.Get("@AgencyModulePermissionXML", agencyModulePermissionXML));

        }

        public async Task<List<HeaderPermissionResponseDto>> GetHeaderPermissionById( int agencyModuleId)
        {
            List<HeaderPermissionResponseDto> headerPermission;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync("usp_hatzalah_GetModulePermissionById", _dbContext.GetDapperDynamicParameters(
                      _parameterManager.Get("@AgencyModuleId", agencyModuleId)
                    ),
                    commandType: CommandType.StoredProcedure);
                headerPermission = result.Read<HeaderPermissionResponseDto>().ToList();
                dbConnection.Close();
            }
            return (headerPermission);
        }
        public async Task<List<DashboardPermissionResponseDto>> GetDashboardPermissionById(int agencyModuleId)
        {
            List<DashboardPermissionResponseDto> dashboardPermission;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync("usp_hatzalah_GetModulePermissionById", _dbContext.GetDapperDynamicParameters(
                     _parameterManager.Get("@AgencyModuleId", agencyModuleId)
                     ),
                    commandType: CommandType.StoredProcedure);
                dashboardPermission = result.Read<DashboardPermissionResponseDto>().ToList();
                dbConnection.Close();
            }
            return (dashboardPermission);
        }
        public async Task<List<ReportPermissionResponseDto>> GetReportPermissionById(int agencyModuleId)
        {
            List<ReportPermissionResponseDto> reportPermission;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync("usp_hatzalah_GetModulePermissionById", _dbContext.GetDapperDynamicParameters(
                     _parameterManager.Get("@AgencyModuleId", agencyModuleId)
                     ),
                    commandType: CommandType.StoredProcedure);
                reportPermission = result.Read<ReportPermissionResponseDto>().ToList();
                dbConnection.Close();
            }
            return (reportPermission);
        }
        public async Task<List<CallHistoryPermissionResponseDto>> GetCallHistoryPermissionById(int agencyModuleId)
        {
            List<CallHistoryPermissionResponseDto> callhistoryPermission;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync("usp_hatzalah_GetModulePermissionById", _dbContext.GetDapperDynamicParameters(
                     _parameterManager.Get("@AgencyModuleId", agencyModuleId)
                     ),
                    commandType: CommandType.StoredProcedure);
                callhistoryPermission = result.Read<CallHistoryPermissionResponseDto>().ToList();
                dbConnection.Close();
            }
            return (callhistoryPermission);
        }
        public async Task<List<ContactPermissionResponseDto>> GetContactPermissionById(int agencyModuleId)
        {
            List<ContactPermissionResponseDto> contactPermission;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync("usp_hatzalah_GetModulePermissionById", _dbContext.GetDapperDynamicParameters(
                     _parameterManager.Get("@AgencyModuleId", agencyModuleId)
                     ),
                    commandType: CommandType.StoredProcedure);
                contactPermission = result.Read<ContactPermissionResponseDto>().ToList();
                dbConnection.Close();
            }
            return (contactPermission);
        }
        public async Task<List<ShiftSchedulePermissionResponseDto>> GetShiftSchedulePermissionById(int agencyModuleId)
        {
            List<ShiftSchedulePermissionResponseDto> shiftschedulePermission;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync("usp_hatzalah_GetModulePermissionById", _dbContext.GetDapperDynamicParameters(
                     _parameterManager.Get("@AgencyModuleId", agencyModuleId)
                     ),
                    commandType: CommandType.StoredProcedure);
                shiftschedulePermission = result.Read<ShiftSchedulePermissionResponseDto>().ToList();
                dbConnection.Close();
            }
            return (shiftschedulePermission);
        }
        public async Task<List<MemberPermissionResponseDto>> GetMemberPermissionById(int agencyModuleId)
        {
            List<MemberPermissionResponseDto> memberPermission;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync("usp_hatzalah_GetModulePermissionById", _dbContext.GetDapperDynamicParameters(
                     _parameterManager.Get("@AgencyModuleId", agencyModuleId)
                     ),
                    commandType: CommandType.StoredProcedure);
                memberPermission = result.Read<MemberPermissionResponseDto>().ToList();
                dbConnection.Close();
            }
            return (memberPermission);
        }

        public async Task<List<GetAdminModulePermissionResponseDto>> GetAdminModulePermissionById(int agencyModuleId)
        {
            List<GetAdminModulePermissionResponseDto> adminModulePermission;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync("usp_hatzalah_GetModulePermissionById", _dbContext.GetDapperDynamicParameters(
                     _parameterManager.Get("@AgencyModuleId", agencyModuleId)
                     ),
                    commandType: CommandType.StoredProcedure);
                adminModulePermission = result.Read<GetAdminModulePermissionResponseDto>().ToList();
                dbConnection.Close();
            }
            return (adminModulePermission);
        }
    }
}
