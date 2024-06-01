using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Application.Common.Dtos;
using Dapper;
using Domain.Entities;
using DTO.Request.CallHistory;
using DTO.Request.Report;
using DTO.Response.Member;
using DTO.Response.Report;
using System.Data;

namespace Infrastructure.Implementation.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;
        public ReportRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;
        }

        public async Task<(List<MemberReportSummaryResult>, int)> GetMembersSummaryForReport(int year, bool isNSCoordinator, ServerRowsRequest commonRequest, string filterModel, string getSort, int? emergencyType)
        {
            int total = 0;
            var memberReportSummaryResult = new List<MemberReportSummaryResult>();
            List<MemberReportSummaryDto> admin;
            //List<ResExperties> experties;
            List<MemberReportCountsDto> totalCounts;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
                   "usp_hatzalah_GetMembersSummaryForReport", _dbContext.GetDapperDynamicParameters
                  (_parameterManager.Get("@Year", year),
                  _parameterManager.Get("@IsNSCoordinator", isNSCoordinator),                 
                  _parameterManager.Get("@StartRow", commonRequest.StartRow),
                  _parameterManager.Get("@EndRow", commonRequest.EndRow),
                  _parameterManager.Get("@FilterModel", filterModel),
                  _parameterManager.Get("@OrderBy", getSort),
                  _parameterManager.Get("@SearchText", commonRequest.SearchText),
                  _parameterManager.Get("@EmergencyTypeId", emergencyType)),
                  commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                admin = result.Read<MemberReportSummaryDto>().ToList();
                //experties = result.Read<ResExperties>().ToList();
                totalCounts = result.Read<MemberReportCountsDto>().ToList();
                dbConnection.Close();
                memberReportSummaryResult.Add(new MemberReportSummaryResult
                {
                    members = admin,
                    counts = totalCounts,
                    //expertisesList = experties

                });
            }
            return (memberReportSummaryResult, total);

        }

        public async Task<(List<GetMembersReportByDateRangeResponseDto>, int)> GetMembersReportByDateRange(DateTime fromTime, DateTime toTime, string dayFromTime, string dayToTime, string nightFromTime, string nightToTime, bool byDate, bool isNSCoordinator, ServerRowsRequest commonRequest, string filterModel, string getSort, int? emergencyType)
        {
            int total = 0;
            var memberReportResult = new List<GetMembersReportByDateRangeResponseDto>();
            List<MemberReportDto> admin;
           // List<ResExperties> experties;
            List<MemberReportCountsDto> totalCounts;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
                   "usp_hatzalah_GetMembersReportByDateRange", _dbContext.GetDapperDynamicParameters
                     (_parameterManager.Get("@FromTime", fromTime, ParameterDirection.Input, DbType.Date),
                  _parameterManager.Get("@ToTime", toTime, ParameterDirection.Input, DbType.Date),
                  _parameterManager.Get("@DayFromTime", dayFromTime),
                  _parameterManager.Get("@DayToTime", dayToTime),
                  _parameterManager.Get("@NightFromTime", nightFromTime),
                  _parameterManager.Get("@NightToTime", nightToTime),
                  _parameterManager.Get("@ByDate", byDate),
                  _parameterManager.Get("@IsNSCoordinator", isNSCoordinator),
                  _parameterManager.Get("@StartRow", commonRequest.StartRow),
                  _parameterManager.Get("@EndRow", commonRequest.EndRow),
                  _parameterManager.Get("@FilterModel", filterModel),
                  _parameterManager.Get("@OrderBy", getSort),
                  _parameterManager.Get("@SearchText", commonRequest.SearchText),
                  _parameterManager.Get("@EmergencyTypeId", emergencyType)),
                  commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                admin = result.Read<MemberReportDto>().ToList();
                //experties = result.Read<ResExperties>().ToList();
                totalCounts = result.Read<MemberReportCountsDto>().ToList();
                dbConnection.Close();
                memberReportResult.Add(new GetMembersReportByDateRangeResponseDto
                {
                    members = admin,
                    counts = totalCounts,
                    //expertisesList = experties
                });
            }
            return (memberReportResult, total);
        }

        public async Task<GetCallHistoryDetailResponseDto> GetCallHistoryDetail(int clientId)
        {
            var Data = new List<GetCallHistoryDetailResponseDto>();
            GetCallHistoryDetailResponseDto activeResponse;
            List<Hospital> hospitals;
            List<MemberOnMembersTable> memberOnMembersTables;
            List<StatusInfo> statusInfos;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
                   "usp_hatzalah_GetCallHistoryDetailByClientId", _dbContext.GetDapperDynamicParameters
                  (_parameterManager.Get("@clientId", clientId)),
                  commandType: CommandType.StoredProcedure);
                activeResponse = result.Read<GetCallHistoryDetailResponseDto>().FirstOrDefault();
                statusInfos = result.Read<StatusInfo>().ToList();
                hospitals = result.Read<Hospital>().ToList();
                memberOnMembersTables = result.Read<MemberOnMembersTable>().ToList();
                dbConnection.Close();
                activeResponse.dismissedEventOptions = statusInfos;
                activeResponse.hospitalOptions = hospitals;
                activeResponse.members = memberOnMembersTables;
               
            }
            return activeResponse;

        }

        public async Task<IList<GetClientActivityLogsResponseDto>> GetClientActivityLogs(int clientId)
        {
            return await _dbContext.ExecuteStoredProcedureList<GetClientActivityLogsResponseDto>("usp_hatzalah_GetClientActivityLogsByClientId",
           _parameterManager.Get("@ClientId", clientId));
        }

        public async Task<IList<GetCallHistoryNotesResponseDto>> GetCallHistoryNotes(int clientId)
        {
            return await _dbContext.ExecuteStoredProcedureList<GetCallHistoryNotesResponseDto>("usp_hatzalah_GetCallHistoryNotesByClientId",
          _parameterManager.Get("@ClientId", clientId));
        }

        public async Task<int> AddCallHistoryNote(AddCallHistoryNoteRequestDto addCallHistoryNote)
        {
            return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_AddCallHistoryNote",
           _parameterManager.Get("@ClientId", addCallHistoryNote.clientId),
           _parameterManager.Get("@Note", addCallHistoryNote.note),
           _parameterManager.Get("@CreatedBy", addCallHistoryNote.createdBy)
           
           );

        }

        public async Task<List<SendThankyouMessageToAllCommandResponseDto>> GetThankYouMessage(bool isNSCoordinator, int month, int year, string expertise)
        {
            var thankYouMessageResponseDto = new List<SendThankyouMessageToAllCommandResponseDto>();
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
                   "usp_hatzalah_GetThankYouMessage", _dbContext.GetDapperDynamicParameters
                  (_parameterManager.Get("@IsNSCoordinator", isNSCoordinator),
                    _parameterManager.Get("@Month", month),
                    _parameterManager.Get("@Year", year),
                    _parameterManager.Get("@Expertise", expertise)),
                  commandType: CommandType.StoredProcedure);
                thankYouMessageResponseDto = result.Read<SendThankyouMessageToAllCommandResponseDto>().ToList();
                dbConnection.Close();
                
            }
            return thankYouMessageResponseDto;
        }

        public async Task<Members> GetMemberAndPhoneByBadge(string badgeNumber)
        {
            return await _dbContext.ExecuteStoredProcedure<Members>("usp_hatzalah_GetMemberAndPhoneByBadge",
           _parameterManager.Get("@BadgeNumber", badgeNumber));
        }
        //*****************
        public async Task<Clients> GetClientById(int clientId)
        {
            return await _dbContext.ExecuteStoredProcedure<Clients>("usp_hatzalah_GetClientById",
           _parameterManager.Get("@ClientId", clientId));
        }

        public async Task<MemberAndPhoneDto> GetByUserID(Guid user_id)
        {
            MemberAndPhoneDto members;
            List<ResMembers> resMembers;
            List<ResMemberPhones> resMemberPhones;
            List<ResMemberExpertises> memberExpertieses;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync("usp_hatzalah_GetByUserID", _dbContext.GetDapperDynamicParameters(
                 _parameterManager.Get("@UserId", user_id.ToString())),
                      commandType: CommandType.StoredProcedure);
                resMembers = result.Read<ResMembers>().ToList();
                resMemberPhones = result.Read<ResMemberPhones>().ToList();
                memberExpertieses = result.Read<ResMemberExpertises>().ToList();
                dbConnection.Close();
            }
            var data = new MemberAndPhoneDto
            {
                members = resMembers,
                memberPhones = resMemberPhones,
                memberExpertieses = memberExpertieses,
            };
            return data;
        }
       
        public async Task<ClientMembers> GetClientMember(int clientId, Guid memberId)
        {
            return await _dbContext.ExecuteStoredProcedure<ClientMembers>("usp_hatzalah_GetClientMember",
           _parameterManager.Get("@ClientId", clientId),
           _parameterManager.Get("@MemberId", memberId.ToString()));
        }

        public async Task<List<ClientMembers>> GetAssignedDriverMember(int clientId)
        {
            var membersRes = new List<ClientMembers>();
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync("usp_hatzalah_GetAssignedDriverMember", _dbContext.GetDapperDynamicParameters(
                 _parameterManager.Get("@ClientId", clientId)),
                      commandType: CommandType.StoredProcedure);
                membersRes = result.Read<ClientMembers>().ToList();
                dbConnection.Close();
            }
            return membersRes;
        }

        public async Task<List<HospitalInfoMessageResponse>> GetHospitalInfoMessage(int clientId, Guid? memberId = null)
        {
            var hospitalInfoMessageRes = new List<HospitalInfoMessageResponse>();
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync("usp_hatzalah_GetHospitalInfoMessage", _dbContext.GetDapperDynamicParameters(
                _parameterManager.Get("@Client_id", clientId),
                _parameterManager.Get("@MemberId", memberId.ToString())),
                      commandType: CommandType.StoredProcedure);
                hospitalInfoMessageRes = result.Read<HospitalInfoMessageResponse>().ToList();
                dbConnection.Close();
            }
            return hospitalInfoMessageRes;
        }

        public async Task<LoggedInDispatcherResponse> GetDispatcherInfo()
        {
            return await _dbContext.ExecuteStoredProcedure<LoggedInDispatcherResponse>("usp_hatzalah_GetDispatcherInfo");
        }

        public async Task<Clients> UpdateClientById(Clients clients)
        {
            return await _dbContext.ExecuteStoredProcedure<Clients>("usp_hatzalah_UpdateClientById",
               _parameterManager.Get("@ClientId", clients.Id),
           _parameterManager.Get("@Call_status", clients.call_status),
            _parameterManager.Get("@MappedCallStatus", clients.MappedCallStatus),
            _parameterManager.Get("@Unit", clients.units),
            _parameterManager.Get("@FromSceneTime", clients.FromSceneTime),
            _parameterManager.Get("@UpdatedBy", clients.UpdatedBy));
        }

        public async Task<ClientMembers> UpdateMember(ClientMembers clientMembers)
        {
            
            {
                return await _dbContext.ExecuteStoredProcedure<ClientMembers>("usp_hatzalah_UpdateMember",
             _parameterManager.Get("@Id", clientMembers.Id),
         _parameterManager.Get("@SceneOnly", clientMembers.SceneOnly),
          _parameterManager.Get("@Transport", clientMembers.Transport),
          _parameterManager.Get("@Driver", clientMembers.Driver));
            }
           
           
        }

        public async Task<List<BusDriverNotificationDto>> GetBusDriverNotification(int id)
        {
            return await _dbContext.ExecuteStoredProcedure<List<BusDriverNotificationDto>>("usp_hatzalah_GetBusDriverNotification",
               _parameterManager.Get("@ClientId",id));
        }

        public async Task<List<TextMessageMemberAddition>> GetAllValidMessageInformations(DateTime lastValidDate, int clientId)
        {
            return await _dbContext.ExecuteStoredProcedure< List<TextMessageMemberAddition>>("usp_hatzalah_GetAllValidMessageInformations",
               _parameterManager.Get("@LastValidDate",lastValidDate),
           _parameterManager.Get("@ClientId",clientId ));
        }

        public async Task<TextMessageMemberAddition> UpsertOutboundMessage(TextMessageMemberAddition addition, DateTime lastValidDate)
        {
            return await _dbContext.ExecuteStoredProcedure<TextMessageMemberAddition>("usp_hatzalah_UpsertOutboundMessage",
            _parameterManager.Get("@Id", addition.Id),
            _parameterManager.Get("@ForBus", addition.ForBus),
            _parameterManager.Get("@ForScene", addition.ForScene),
            _parameterManager.Get("@ClientId", addition.ClientId));
        }

        public async Task<Setting> UpdateNightCallTimes(Setting setting)
        {
            return await _dbContext.ExecuteStoredProcedure<Setting>("usp_hatzalah_UpdateNightCallTimes",
            _parameterManager.Get("@Id", setting.Id),
            _parameterManager.Get("@SettingName", setting.SettingName),
            _parameterManager.Get("@IsActive", setting.IsActive),
            _parameterManager.Get("@JsonProperties", setting.JsonProperties));
        }

        public async Task<Setting> AddNightCallTimes(Setting setting)
        {
            return await _dbContext.ExecuteStoredProcedure<Setting>("usp_hatzalah_AddNightCallTimes",
            _parameterManager.Get("@SettingName", setting.SettingName),
            _parameterManager.Get("@IsActive", setting.IsActive),
            _parameterManager.Get("@JsonProperties", setting.JsonProperties));
        }

        public async Task<(List<GetMembersReportByDateRangeResponseDto>, int)> GetMembersReportByEmergencyTypeMonthYear(string filterModel, string getSorts, ServerRowsRequest commonRequest,int month, int year, int? emergencyType = null)
        {
            int total = 0;
            var memberReportResult = new List<GetMembersReportByDateRangeResponseDto>();
            List<MemberReportDto> admin;
            List<MemberReportCountsDto> totalCounts;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
                   "usp_hatzalah_GetMembersReportByEmergencyTypeMonthYear", _dbContext.GetDapperDynamicParameters
                     (_parameterManager.Get("@month", month),
                  _parameterManager.Get("@year", year),
                  _parameterManager.Get("@emergencyTypeId", emergencyType),
                  _parameterManager.Get("@StartRow", commonRequest.StartRow),
                  _parameterManager.Get("@EndRow", commonRequest.EndRow),
                  _parameterManager.Get("@FilterModel", filterModel),
                  _parameterManager.Get("@OrderBy", getSorts),
                  _parameterManager.Get("@SearchText", commonRequest.SearchText)),
                  commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                admin = result.Read<MemberReportDto>().ToList();
                totalCounts = result.Read<MemberReportCountsDto>().ToList();
                dbConnection.Close();
                memberReportResult.Add(new GetMembersReportByDateRangeResponseDto
                {
                    members = admin,
                    counts = totalCounts,
                });
            }
            return (memberReportResult, total);
        }

        public async Task<IList<ClientsUnitsResponseDto>> GetClientUnitsDetails()
        {
            return await _dbContext.ExecuteStoredProcedureList<ClientsUnitsResponseDto>("usp_hatzalah_GetClientUnitsDetails");
        }

        public async Task<(List<GetCallHistoryShabbosHourlyResponseDto>, int)> GetCallHistoryShabbosHourly(DateTime fromTime, DateTime toTime, ServerRowsRequest commonRequest, string filterModel, string getSort, bool isShabbosOnly)
        {
            int total = 0;
            var memberReportResult = new List<GetCallHistoryShabbosHourlyResponseDto>();
            List<GetCallHistoryMemberShabbosHourlyDto> admin;
            List<MemberReportCountsDto> totalCounts;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
                   "usp_hatzalah_GetCallHistoryShabbosHourly", _dbContext.GetDapperDynamicParameters
                     (_parameterManager.Get("@FromTime", fromTime, ParameterDirection.Input, DbType.Date),
                  _parameterManager.Get("@ToTime", toTime, ParameterDirection.Input, DbType.Date),
                  _parameterManager.Get("@IsShabbosOnly", isShabbosOnly),
                  _parameterManager.Get("@StartRow", commonRequest.StartRow),
                  _parameterManager.Get("@EndRow", commonRequest.EndRow),
                  _parameterManager.Get("@FilterModel", filterModel),
                  _parameterManager.Get("@OrderBy", getSort),
                  _parameterManager.Get("@SearchText", commonRequest.SearchText)),
                  commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                admin = result.Read<GetCallHistoryMemberShabbosHourlyDto>().ToList();
                totalCounts = result.Read<MemberReportCountsDto>().ToList();
                dbConnection.Close();
                memberReportResult.Add(new GetCallHistoryShabbosHourlyResponseDto
                {
                    members = admin,
                    counts = totalCounts,
                });
            }
            return (memberReportResult, total);
        }
    }
}
